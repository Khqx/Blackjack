using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models
{
    public class Deck
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private List<Card> _deck = new List<Card>();

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public Deck()
        {
            InitializeDeck();
            Shuffle();
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        private void InitializeDeck()
        {
            // Defines families, names and values
            string[] suits = { "Hearts", "Diamonds", "Spades", "Clubs" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

            // Looping through each family
            foreach (string s in suits)
            {
                // Looping through every cards (13)
                for (int i = 0; i < ranks.Length; i++)
                {
                    // Adds a card into the deck
                    _deck.Add(new Card(s, ranks[i], values[i]));
                }
            }
        }

        private void Shuffle()
        {
            // Random number generator
            Random rng = new Random();
            // Shuffles the deck in a random order
            _deck = _deck.OrderBy(_ => rng.Next()).ToList();
        }

        public Card DrawCard()
        {
            if (_deck.Count > 0)
            {
                // Draws the first card in the deck
                Card drawnCard = _deck[0];
                // Removes the first card from the deck
                _deck.RemoveAt(0);
                // Returns the result
                return drawnCard;
            }
            else
            {
                // Error handler (empty deck)
                throw new InvalidOperationException("Deck is empty");
            }
        }

        public int Count() => _deck.Count;

    }
}
