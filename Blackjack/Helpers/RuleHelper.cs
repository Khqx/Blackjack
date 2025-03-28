using Blackjack.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Blackjack.Helpers
{
    public static class RuleHelper
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private const int C_BLACKJACK_HAND_COUNT = 2;
        private const int C_BLACKJACK_HAND_COUNT_LIMIT = 5;
        private const int C_BLACKJACK_HAND_SCORE_LIMIT = 21;
        private const int C_ACE_VALUE_11 = 11;
        private const int C_ACE_VALUE_10 = 10;
        private const int C_ACE_VALUE_1 = 1;

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        //--------------------------------------------------
        // BLACKJACK RULES (CONTROLS)
        //--------------------------------------------------
        public static bool IsBlackjack(Hand hand) 
        {
            // Variables
            Card firstCard = hand.Cards[0];
            Card secondCard = hand.Cards[1];

            // First control: 2 cards count
            if (hand.Cards.Count == C_BLACKJACK_HAND_COUNT) 
            {
                // Second control: Value combination of 21
                return (firstCard.Value == 11 && IsTenValue(secondCard)) ||
                       (secondCard.Value == 11 && IsTenValue(firstCard));
            }
            // Default result
            return false;
        }

        private static bool IsTenValue(Card card) 
        {
            // Checks that card value can be 10
            return card.Value == 10 || 
                   card.Value == 11;
        }

        //--------------------------------------------------
        // CALCULATION RULES
        //--------------------------------------------------
        private static int CalculateAce(int score)
        {
            // Default value of Ace = 11
            int ace = C_ACE_VALUE_11;

            // If current score + Ace > 21
            if (score + C_ACE_VALUE_11 > C_BLACKJACK_HAND_SCORE_LIMIT)
            {
                // If current score + Ace > 21
                if (score + C_ACE_VALUE_10 > C_BLACKJACK_HAND_SCORE_LIMIT)
                    // Ace = 1
                    ace = C_ACE_VALUE_1;
                else
                    // Ace = 10
                    ace = C_ACE_VALUE_10;
            }
            
            // Returns result
            return ace;
        }

        public static int Calculate(Hand hand)
        {
            // Score initialization
            int score = 0;

            // Checks that the hand is holding cards
            if (hand.Cards.Count > 0)
            {
                // Copy of the original object before ordering the cards
                List<Card> subCards = new List<Card>(hand.Cards.OrderBy(c => c.Value));
                // Looping through the cards
                foreach (Card sub in subCards)
                {
                    // Any non-Ace card
                    if (sub.Value != C_ACE_VALUE_11)
                        // Default calculation
                        score = score + sub.Value;
                    else
                        // Ace calculation
                        score = score + CalculateAce(score);
                    
                }
            }
            // Returns result
            return score;
        }

        public static bool IsOverflow(int score)
        {
            // Default return
            return score <= C_BLACKJACK_HAND_SCORE_LIMIT;
        }

        //--------------------------------------------------
        // DRAWING RULES
        //--------------------------------------------------
        public static bool CanDraw(int cardCount)
        {
            // Variable
            bool allowDrawing = false;

            // If card count < holding card limit
            if (cardCount < C_BLACKJACK_HAND_COUNT_LIMIT)
                // Allows drawing
                allowDrawing = true;

            // Default return
            return allowDrawing;
        }
    }
}
