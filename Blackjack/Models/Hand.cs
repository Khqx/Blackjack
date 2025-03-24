using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    public class Hand
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private List<Card> Cards;
        private readonly Deck _Deck;

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public Hand(ref Deck deck) 
        {
            Cards = new List<Card>();
            _Deck = deck;
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        public void Draw() 
        {
            if (this.Count() < 5) 
            {
                Cards.Add(_Deck.DrawCard());
            }
                
        }
        
        public void Throw() 
        {
            Cards.Clear();
        }

        public int Calculate() 
        {
            int total = 0;
            if(Cards.Count > 0) 
            {
                foreach (Card card in Cards) 
                {
                    total = total + card.Value;
                }
            }
            return total;
        }

        public int Count() => Cards.Count;

    }
}
