using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsCLI.Model
{
    internal class Card
    {
        public string Code {  get; set; }
        public string Image { get; set; }
        public Dictionary<string, string> Images { get; set; }
        public string Value { get; set; }
        public CardSuit Suit { get; set; }

        public static readonly Dictionary<string, int> Priorities = new()
        {
            { "ACE", 14 },
            { "KING", 13 },
            { "QUEEN", 12 },
            { "JACK", 11 },
            { "10", 10 },
            { "9", 9 },
            { "8", 8 },
            { "7", 7 },
            { "6", 6 },
            { "5", 5 },
            { "4", 4 },
            { "3", 3 },
            { "2", 2 }
        };

    }
}
