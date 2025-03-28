using Blackjack.Models;
using System.Reflection;

namespace Blackjack.Controllers
{
    public class LocalizationController
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private const string C_LOCALIZATION_PATH = "Blackjack.Resources.Localization.translations_all.csv";
        private const string C_LOCALIZATION_HEADER_LABEL = "CODENAME";
        private bool _Initialized;
        private Dictionary<string, Localization> _Translations;
        public enum Language 
        {
            English = 0,
            French = 1,
            Swedish = 2
        }

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public LocalizationController() 
        {
            _Translations = new Dictionary<string, Localization>();
            _Initialized = false;
        }

        //==============================================================================================
        // FUNCTIONS & PROCEDURES
        //==============================================================================================
        public void LoadTranslations()
        {
            // Variables
            Assembly assembly = Assembly.GetExecutingAssembly(); // Loads the current assembly as reflection
            string[] values;

            // Loads embedded translation file (Blackjack.Resources.Localization.translations_all.csv) using reflection
            using (Stream? stream = assembly.GetManifestResourceStream(C_LOCALIZATION_PATH))
            {
                // Verifies that the file exists
                if (stream == null)
                    throw new InvalidOperationException($"Resource {C_LOCALIZATION_PATH} not found.");

                // Opens a reading stream for the embedded translation file
                using (StreamReader sr = new StreamReader(stream))
                {
                    // If the file can be read
                    if (sr != null)
                    {
                        // Reads each line until the end of the file
                        while (!sr.EndOfStream)
                        {
                            // Reads the next line and splits by columns
                            values = sr.ReadLine()!.Split(";");
                            // Skips the headers (firstRow)
                            if (values[0]!=C_LOCALIZATION_HEADER_LABEL)
                            {
                                // Adds the translation reference in a dictionary<key, value>
                                _Translations.Add(values[0], new Localization(values[1], values[2], values[3]));
                            }
                        }
                    }
                    else
                        // TODO: Try to generate and error and handle the exception properly
                        throw new InvalidOperationException($"");

                    // Memorizes initialization
                    _Initialized = true;
                }
            };
        }
        public string GetTranslation(string key, Language language = Language.English)
        {
            // Variables
            string translation = String.Empty;
            
            // Language settings
            switch (language) 
            {
                case Language.English:
                    translation = _Translations[key]._English;
                    break;

                case Language.French:
                    translation = _Translations[key]._French;
                    break;

                case Language.Swedish:
                    translation = _Translations[key]._Swedish;
                    break;

                default:
                    // Do Nothing
                    break;
            }
            // Returns translation
            return translation;
        }

        public int Count() => _Translations.Count;
    }
}
