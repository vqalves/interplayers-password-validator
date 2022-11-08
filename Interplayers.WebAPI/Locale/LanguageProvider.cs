using Interplayers.Infrastructure.Implementations.Locale;
using Interplayers.Infrastructure.Implementations.Locale.Languages;
using Interplayers.Infrastructure.Implementations.Locale.Languages.English;
using Interplayers.Infrastructure.Implementations.Locale.Languages.Portuguese;

namespace Interplayers.WebAPI.Locale.Languages
{
    public class LanguageProvider : ILanguageProvider
    {
        private readonly LanguageEnglish English;
        private readonly LanguagePortuguese Portuguese;

        public LanguageProvider()
        {
            this.English = new LanguageEnglish();
            this.Portuguese = new LanguagePortuguese();
        }

        public IEnumerable<ILanguage> ListAllLanguages()
        {
            yield return English;
            yield return Portuguese;
        }

        public ILanguage? GetDefaultLanguage()
        {
            return English;
        }

        public ILanguage? GetMatchedLanchage(string language)
        {
            return ListAllLanguages().FirstOrDefault(x => x.MatchesAcceptedLanguage(language));
        }
    }
}