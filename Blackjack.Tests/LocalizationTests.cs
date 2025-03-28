using Blackjack.Controllers;
using Xunit.Abstractions;

namespace Blackjack.Tests
{
    public class LocalizationTests
    {
        //==============================================================================================
        // PROPERTIES & ACCESSORS
        //==============================================================================================
        private readonly ITestOutputHelper _output;
        private LocalizationController _controller;

        //==============================================================================================
        // CONSTRUCTOR
        //==============================================================================================
        public LocalizationTests(ITestOutputHelper output)
        {
            _output = output;
            _controller = new LocalizationController();
        }

        //==============================================================================================
        // TEST
        //==============================================================================================
        [Fact]
        public void Localization_LoadConfiguration()
        {
            _controller.LoadTranslations();
            Assert.NotEqual(0, _controller.Count());
            _output.WriteLine("Translations count: {0}", _controller.Count());
        }
        
        [Theory]
        [InlineData("TEST_VAR1", "New Game", LocalizationController.Language.English)]
        [InlineData("TEST_VAR1", "Nouvelle Partie", LocalizationController.Language.French)]
        [InlineData("TEST_VAR1", "Nytt Spel", LocalizationController.Language.Swedish)]
        public void Localization_VerifyLanguageConfiguration(string key, string expectedValue, LocalizationController.Language language)
        {
            _controller.LoadTranslations();
            string str = String.Empty;

            str = _controller.GetTranslation(key, language);
            Assert.Equal(expectedValue, str);
            _output.WriteLine("{0}: {1}", language, str);

        }

        [Theory]
        [InlineData(4)] //
        public void Localization_DictionaryCount(int count)
        {
            _controller.LoadTranslations();
            Assert.Equal(count, _controller.Count());
            _output.WriteLine("DictionaryCount: {0}", _controller.Count());
        }
    }
}
