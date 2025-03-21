using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    public class Card
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        public string Suit { get; }
        public string Rank { get; }
        public int Value { get; }

        //==============================================================================================
        // CONSTRUCTORS
        //==============================================================================================
        public Card(String suit, string rank, int value)
        {
            Suit = suit;
            Rank = rank;
            Value = value;
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        public override string ToString() => $"{Rank} ({Suit})";
    }
}
