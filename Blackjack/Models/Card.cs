﻿using System;
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
        public string Symbol { get; }
        public string Rank { get; }
        public string Name { get; }
        public int Value { get; }

        //==============================================================================================
        // CONSTRUCTORS
        //==============================================================================================
        public Card(String suit, string symbol, string rank, string name, int value)
        {
            Suit = suit;
            Symbol = symbol;
            Rank = rank;
            Name = name;
            Value = value;
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        public override string ToString() => $"{Symbol} - {Name}";
    }
}
