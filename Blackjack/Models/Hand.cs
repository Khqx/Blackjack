
using Blackjack.Helpers;

namespace Blackjack.Models
{
    public class Hand
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private readonly Deck _Deck;
        public List<Card> Cards;
        public int Score { get; private set; }
        public bool IsOverflow { get; private set; }

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public Hand(ref Deck deck) 
        {
            Cards = new List<Card>();
            _Deck = deck;
            Score = 0;
            IsOverflow = false;
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        public void Draw() 
        {
            // If allowed to draw
            if (RuleHelper.CanDraw(Cards.Count)) 
                // Draws a card from the deck
                Cards.Add(_Deck.DrawCard());    
        }
        
        public void Throw() 
        {
            // Clears the list of Cards from the Hand
            Cards.Clear();
        }

        public void Calculate() 
        {
            // Updates the Hand score
            Score = RuleHelper.Calculate(this);
            // Updates the Hand overflow state
            IsOverflow = RuleHelper.IsOverflow(Score);
        }

    }
}
