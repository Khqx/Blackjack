using Blackjack.Models;

namespace Blackjack.Tests
{
    public class CardTests
    {
        [Theory]
        [InlineData("Spades", "♠", "9", "9",9)]
        [InlineData("Diamonds", "♦", "Jack", "J", 10)]
        [InlineData("Hearts", "♥", "Ace", "A", 11)]
        public void NewCard_CorrectlyCreated(string suit, string symbol, string rank, string name, int value)
        {
            var card = new Card(suit, symbol, rank, name, value);
            Assert.Equal(suit, card.Suit);
            Assert.Equal(symbol, card.Symbol);
            Assert.Equal(rank, card.Rank);
            Assert.Equal(name, card.Name);
            Assert.Equal(value, card.Value);
        }
    }
}