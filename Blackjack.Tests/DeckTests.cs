using Blackjack.Models;
using Xunit.Abstractions;

namespace Blackjack.Tests
{
    public class DeckTests
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private readonly ITestOutputHelper _output;

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public DeckTests(ITestOutputHelper output) { 
            _output = output; 
        }

        //==============================================================================================
        // TESTS
        //==============================================================================================
        [Fact]
        public void NewDeck_ShouldHave52Cards() 
        {
            Deck deck = new Deck();
            Assert.Equal(52, deck.Count());
        }

        [Fact]
        public void NewDeck_CheckEveryCards() 
        {
            Deck deck = new Deck();

            for (int i = 0; i < deck.Count(); i++)
            {
                Assert.NotEqual(String.Empty, deck.Card(i).Suit);
                Assert.NotEqual(String.Empty, deck.Card(i).Symbol);
                Assert.NotEqual(String.Empty, deck.Card(i).Rank);
                Assert.NotEqual(String.Empty, deck.Card(i).Name);
                Assert.NotEqual(0, deck.Card(i).Value);
            }
        }

        [Fact]
        public void Decks_Compare()
        {
            Deck deck1 = new Deck();
            Deck deck2 = new Deck();
            string deck1_output = "";
            string deck2_output = "";

            for (int i = 0; i < 5; i++)
            {
                deck1_output = deck1_output + deck1.Card(i).ToString() + ", ";
                deck2_output = deck2_output + deck2.Card(i).ToString() + ", ";
            }
            _output.WriteLine(deck1_output);
            _output.WriteLine(deck2_output);
        }
    }
}