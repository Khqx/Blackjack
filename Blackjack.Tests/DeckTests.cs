using Blackjack.Models;

namespace Blackjack.Tests
{
    public class DeckTests
    {
        [Fact]
        public void NewDeck_ShouldHave52Cards() 
        {
            var deck = new Deck();
            Assert.Equal(52, deck.Count());
        }
    }
}