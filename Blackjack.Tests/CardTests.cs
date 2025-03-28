using Blackjack.Helpers;
using Blackjack.Models;
using Xunit.Abstractions;

namespace Blackjack.Tests
{
    public class CardTests
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private readonly ITestOutputHelper _output;

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public CardTests(ITestOutputHelper output) 
        {
            _output = output;
        }

        //==============================================================================================
        // TESTS
        //==============================================================================================
        [Theory]
        [InlineData("Spades", SuitHelper.Suit.Spades, "9", "9", 9)]             // Spades 9
        [InlineData("Diamonds", SuitHelper.Suit.Diamonds, "J", "Jack", 10)]     // Diamonds Jack
        [InlineData("Hearts", SuitHelper.Suit.Hearts,"A", "Ace", 11)]           // Hearts Ace
        public void NewCard_CorrectlyCreated(string suit, SuitHelper.Suit symbol, string rank, string name, int value)
        {
            // Creation of a Card object
            Card card = new Card(suit, symbol, rank, name, value);
            
            // Verification of the properties accessibility
            Assert.Equal(suit, card.Suit);
            Assert.Equal(SuitHelper.Symbol(symbol), card.Symbol);
            Assert.Equal(rank, card.Rank);
            Assert.Equal(name, card.Name);
            Assert.Equal(value, card.Value);

            // Written output
            _output.WriteLine($"{card.Symbol} - {card.Name}: {card.Value}");
        }
    }
}