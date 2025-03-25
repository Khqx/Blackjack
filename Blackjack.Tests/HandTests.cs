using Blackjack.Models;

namespace Blackjack.Tests
{
    public class HandTests
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private Deck _deck;
        private Hand _hand;

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public HandTests() // xUnit calls this before each test
        {
            _deck = new Deck();
            _hand = new Hand(ref _deck);
        }

        //==============================================================================================
        // TESTS
        //==============================================================================================
        [Fact]
        public void NewHand_Creation() 
        {
            Assert.Equal(0, _hand.Count());
        }

        [Fact]
        public void NewHand_DrawCardFromDeck()
        {
            Assert.Equal(52, _deck.Count());
            Assert.Equal(0, _hand.Count());
            
            _hand.Draw();
            
            Assert.Equal(51, _deck.Count());
            Assert.Equal(1, _hand.Count());
        }

        [Fact]
        public void NewHand_DrawCardAndThrowHand()
        {
            Assert.Equal(52, _deck.Count());
            Assert.Equal(0, _hand.Count());

            _hand.Draw();

            Assert.Equal(51, _deck.Count());
            Assert.Equal(1, _hand.Count());

            _hand.Throw();

            Assert.Equal(51, _deck.Count());
            Assert.Equal(0, _hand.Count());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void NewHand_DrawMax5Cards(int draws)
        {
            Assert.Equal(52, _deck.Count());
            Assert.Equal(0, _hand.Count());

            for (int i = 0; i < draws; i++)
            {
                _hand.Draw();
            }

            Assert.Equal(47, _deck.Count());
            Assert.Equal(5, _hand.Count());
        }
    }
}
