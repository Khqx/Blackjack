
namespace Blackjack.Models
{
    public class Localization
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        public readonly string _English;

        public readonly string _French;

        public readonly string _Swedish;

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public Localization(string english, string french, string swedish) 
        { 
            _English = english;
            _French = french;
            _Swedish = swedish;
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================

    }
}
