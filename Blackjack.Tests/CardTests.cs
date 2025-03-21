using Blackjack.Models;

namespace Blackjack.Tests
{
    public class CardTests
    {
        [Theory]
        [InlineData("Spades","9",9)]
        [InlineData("Diamonds", "Ace", 11)]
        public void NewCard_CorrectlyCreated(string suit, string rank, int value)
        {
            var card = new Card(suit, rank, value);
            Assert.Equal(suit, card.Suit);
            Assert.Equal(rank, card.Rank);
            Assert.Equal(value, card.Value);
        }
    }
}