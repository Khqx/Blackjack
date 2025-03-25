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
        // BLACKJACK CONTROLS
        //--------------------------------------------------
        public static bool IsBlackjack(Hand hand) 
        {
            Card firstCard = hand.Cards[0];
            Card secondCard = hand.Cards[1];

            // First control: 2 cards count
            if (hand.Count() == C_BLACKJACK_HAND_COUNT) 
            {
                // Second control: Value combination of 21
                return (firstCard.Value == 11 && IsTenValue(secondCard)) ||
                       (secondCard.Value == 11 && IsTenValue(firstCard));
            }
            return false;
        }

        private static bool IsTenValue(Card card) 
        {
            return card.Value == 10 || 
                   card.Value == 11;
        }

        //--------------------------------------------------
        // CALCULATIONS
        //--------------------------------------------------
        private static int CalculateAce(int total)
        {
            int ace = C_ACE_VALUE_11;
            if (total + C_ACE_VALUE_11 > C_BLACKJACK_HAND_SCORE_LIMIT)
            {
                if (total + C_ACE_VALUE_10 > C_BLACKJACK_HAND_SCORE_LIMIT)
                    ace = C_ACE_VALUE_1;
                else
                    ace = C_ACE_VALUE_10;
            }
            else
                ace = C_ACE_VALUE_11;
            return ace;
        }

        public static int Calculate(Hand hand)
        {
            int total = 0;

            if (hand.Cards.Count > 0)
            {
                List<Card> subCards = new List<Card>(hand.Cards.OrderBy(c => c.Value));
                
                foreach (Card sub in subCards)
                {
                    if (sub.Value == C_ACE_VALUE_11)
                        total = total + CalculateAce(total);
                    else
                        total = total + sub.Value;
                }
            }

            return total;
        }
    }
}
