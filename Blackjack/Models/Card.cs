using Blackjack.Helpers;

namespace Blackjack.Models
{
    public class Card
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        public string Suit { get; } // Spades, Clubs, Hearts, Diamonds
        public string Symbol { get; } // u2660, u2663, u2665, u2666
        public string Rank { get; } // ShortName: J, Q, K, A
        public string Name { get; } // LongName: Jack, Queen, King, Ace
        public int Value { get; }

        //==============================================================================================
        // CONSTRUCTORS
        //==============================================================================================
        public Card(String suit, SuitHelper.Suit symbol, string rank, string name, int value)
        {
            Suit = suit;
            Symbol = SuitHelper.Symbol(symbol);
            Rank = rank;
            Name = name;
            Value = value;
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        public override string ToString() => $"{Symbol} - {Rank}";
    }
}
