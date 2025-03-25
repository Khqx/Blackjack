
namespace Blackjack.Helpers
{
    public static class SuitHelper
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        public enum Suit 
        {
            Spades = 1,
            Clubs = 2,
            Hearts = 3,
            Diamonds = 4
        }
        private enum SymbolUnicode
        {
            Spades = (Char)'\u2660',
            Clubs = (Char)'\u2663',
            Hearts = (Char)'\u2665',
            Diamonds = (Char)'\u2666'
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        public static string Symbol(Suit suitId) 
        {
            string symbol = "";
            if (suitId == Suit.Spades) symbol = Convert.ToChar(SymbolUnicode.Spades).ToString();
            if (suitId == Suit.Clubs) symbol = Convert.ToChar(SymbolUnicode.Clubs).ToString();
            if (suitId == Suit.Hearts) symbol = Convert.ToChar(SymbolUnicode.Hearts).ToString();
            if (suitId == Suit.Diamonds) symbol = Convert.ToChar(SymbolUnicode.Diamonds).ToString();
            return symbol;
        }
    }
}
