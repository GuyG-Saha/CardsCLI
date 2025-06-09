using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CardsCLI.Model;
using System.CommandLine.Parsing;

namespace CardsCLI
{
    public class DeckOfCardsClient
    {
        public const string BASE_URL = "https://www.deckofcardsapi.com/api/deck";
        private static string _deckId;
        private static List<Card> _cards = new();
        public static async Task GenerateNewDeck(int count)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BASE_URL + $"/new/shuffle/?deck_count={count}"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var json = JsonConvert.DeserializeObject<dynamic>(responseData);
                    if (json != null)
                    {
                        if (json.success == "true" && json.shuffled == "true")
                        {
                            _deckId = json.deck_id;
                            Console.WriteLine($"New Deck Id: {_deckId}");
                        }
                    }

                }
            }
        }
        public static async Task DrawCardsFromDeck(int count)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BASE_URL + $"/{_deckId}" + $"/draw/?count={count}"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var json = JsonConvert.DeserializeObject<dynamic>(responseData);
                    if (json != null)
                    {
                        if (json.success == "true")
                        {
                            JArray array = json.cards;
                            Console.WriteLine($"Codes of {count} drawn cards: ");
                            foreach (JToken jToken in array)
                            {
                                Card card = JsonConvert.DeserializeObject<Card>(jToken.ToString());
                                _cards.Add(card);
                                Console.WriteLine(card.Code);
                            }
                        }
                    }
                }
            }
        }
        public static void SortCards() 
        {
            var sorted = _cards
                .OrderBy(c => Card.Priorities[c.Value])
                .ThenBy(c => c.Suit);

            Console.WriteLine("Sorted Cards Codes: ");
            foreach(var card in sorted)
            {
                Console.WriteLine(card.Code);
            }
        }
    }
}
