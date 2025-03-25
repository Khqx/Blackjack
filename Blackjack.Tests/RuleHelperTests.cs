using Blackjack.Helpers;
using Blackjack.Models;
using Xunit.Abstractions;

namespace Blackjack.Tests
{
    public class RuleHelperTests
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private readonly ITestOutputHelper _output;
        private Deck _deck;
        private Hand _hand;

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public RuleHelperTests(ITestOutputHelper output)
        {
            _deck = new Deck();
            _hand = new Hand(ref _deck);
            _output = output;
        }

        //==============================================================================================
        // TESTS
        //==============================================================================================
        [Theory]
        [InlineData(10, 11, true)] // Ace + FaceOrTen
        [InlineData(11, 10, true)] // Ace + FaceOrTen
        [InlineData(11, 11, true)] // Ace + Ace
        [InlineData(10, 10, false)] // FaceOrTen + FaceOrTen
        public void RuleHelper_IsBlackjack(int value1, int value2, bool expectedResult)
        {
            _hand.Cards.Add(new Card("Hearts", SuitHelper.Suit.Hearts, "Card1", "Card1", value1));
            _hand.Cards.Add(new Card("Hearts", SuitHelper.Suit.Hearts, "Card2", "Card2", value2));

            Assert.Equal(expectedResult, RuleHelper.IsBlackjack(_hand));
        }

        [Theory]
        [InlineData(5,   7,  4, 16)] // 16 Score
        [InlineData(10,  7,  8, 25)] // 25 Score, busted
        [InlineData(10, 10, 11, 21)] // 21 Score (10+10+Ace)
        [InlineData(11,  8,  3, 21)] // 21 Score (8+3+Ace) => 11+10 = 21
        public void RuleHelper_CalculateHand(int value1, int value2, int value3, int expectedResult)
        {
            _hand.Cards.Add(new Card("Hearts", SuitHelper.Suit.Hearts, "Card1", "Card1", value1));
            _hand.Cards.Add(new Card("Hearts", SuitHelper.Suit.Hearts, "Card2", "Card2", value2));
            _hand.Cards.Add(new Card("Hearts", SuitHelper.Suit.Hearts, "Card3", "Card3", value3));

            Assert.Equal(expectedResult, RuleHelper.Calculate(_hand));
        }
    }
}
