using Blackjack.Models;

namespace Blackjack.Tests
{
    public class HandTests
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private readonly Deck _deck;
        private readonly Hand _hand;

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
            Assert.Empty(_hand.Cards);
        }

        [Fact]
        public void NewHand_DrawCardFromDeck()
        {
            Assert.Equal(52, _deck.Count());
            Assert.Empty(_hand.Cards);
            
            _hand.Draw();
            
            Assert.Equal(51, _deck.Count());
            Assert.Single(_hand.Cards);
        }

        [Fact]
        public void NewHand_DrawCardAndThrowHand()
        {
            Assert.Equal(52, _deck.Count());
            Assert.Empty(_hand.Cards);

            _hand.Draw();

            Assert.Equal(51, _deck.Count());
            Assert.Single(_hand.Cards);

            _hand.Throw();

            Assert.Equal(51, _deck.Count());
            Assert.Empty(_hand.Cards);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void NewHand_DrawMax5Cards(int draws)
        {
            Assert.Equal(52, _deck.Count());
            Assert.Empty(_hand.Cards);

            for (int i = 0; i < draws; i++)
            {
                _hand.Draw();
            }

            Assert.Equal(47, _deck.Count());
            Assert.Equal(5, _hand.Cards.Count);
        }
    }
}
