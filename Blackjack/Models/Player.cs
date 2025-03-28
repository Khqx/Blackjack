using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    public class Player
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        public string Name { get; }
        public bool IsHuman { get; }
        public int Money { get; set; }
        public Hand Hand { get; }


        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public Player(string name, bool isHuman, ref Deck deck) 
        { 
            Name = name;
            IsHuman = isHuman;
            Hand = new Hand(ref deck);
        }


        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================


    }
}
