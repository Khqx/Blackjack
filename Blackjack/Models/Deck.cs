using Blackjack.Helpers;

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
            // Creation of 52 cards
            InitializeDeck();
            // Randomly shuffle the card order
            Shuffle();
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        private void InitializeDeck()
        {
            // Defines families, names and values
            SuitHelper.Suit[] symbols = { SuitHelper.Suit.Spades, SuitHelper.Suit.Clubs, SuitHelper.Suit.Hearts, SuitHelper.Suit.Diamonds };
            string[] suits = { "Spades", "Clubs", "Hearts", "Diamonds" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] names = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };

            // Looping through each family
            for (int i = 0; i < suits.Length; i++)
            {
                // Looping through every cards (13)
                for (int j = 0; j < ranks.Length; j++)
                {
                    // Adds a card into the deck
                    _deck.Add(new Card(suits[i], symbols[i], ranks[j], names[j], values[j]));
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

        public Card Card(int index)
        {
            return _deck[index];
        }

        public int Count() => _deck.Count;

    }
}
