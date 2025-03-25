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
        public List<Card> Cards;
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
                List<Card> subCards = new List<Card>(Cards);
                subCards.OrderBy(c => c.Value);

                foreach (Card sub in subCards) 
                {
                    if (sub.Rank == "Ace" && (sub.Value + total > 21)) 
                    {
                        if (sub.Rank == "Ace" && (sub.Value - 1 + total > 21))
                        {
                            total = total + 1;
                        }
                        else
                        {
                            total = total + 10;
                        }
                    }
                    total = total + sub.Value;
                }
            }
            return total;
        }

        public int Count() => Cards.Count;

    }
}
