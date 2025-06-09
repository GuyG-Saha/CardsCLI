using Microsoft.Extensions.Configuration.CommandLine;
using System.CommandLine;
 

namespace CardsCLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var deckCardsFirstOption = new Option<string>("--deck")
            {
                Description = "Generate a new shuffled deck of cards",
                IsRequired = true
            };
            var drawCards = new Option<string>("--draw")
            {
                Description = "Draw cards from the deck",
                IsRequired = true
            };

            var rootCommand = new RootCommand("Start CLI cards");
            rootCommand.AddOption(deckCardsFirstOption);
            rootCommand.AddOption(drawCards);

            rootCommand.SetHandler(async (deckArgValue, drawArgValue) =>
            {
                Console.WriteLine($"{deckArgValue}");
                await DeckOfCardsClient.GenerateNewDeck(int.Parse(deckArgValue));
                Console.WriteLine($"{drawArgValue}");
                await DeckOfCardsClient.DrawCardsFromDeck(int.Parse(drawArgValue));

            }, deckCardsFirstOption, drawCards);

            rootCommand.Invoke(args);
            DeckOfCardsClient.SortCards();

        }
    }
}