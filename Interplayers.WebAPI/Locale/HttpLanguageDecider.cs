using Interplayers.Infrastructure.Implementations.Locale;
using Interplayers.Infrastructure.Implementations.Locale.Languages;

namespace Interplayers.WebAPI.Locale
{
    public class HttpLanguageDecider : ILanguageDecider
    {
        private ILanguage Language;

        public HttpLanguageDecider(IHttpContextAccessor contextAcessor, ILanguageProvider languageProvider)
        {
            this.Language = GetMatchedLanguage(contextAcessor, languageProvider) ?? languageProvider.GetDefaultLanguage()!;
        }

        private ILanguage? GetMatchedLanguage(IHttpContextAccessor contextAcessor, ILanguageProvider languageProvider)
        {
            var acceptedLanguages = contextAcessor.HttpContext!.Request.GetTypedHeaders().AcceptLanguage.OrderByDescending(x => x.Quality);

            // Select language based on the highest quality rating
            foreach(var acceptedLanguage in acceptedLanguages)
            {
                var headerLanguage = acceptedLanguage.Value.Value;
                var matchedLanguage = languageProvider.GetMatchedLanchage(headerLanguage);
                
                if(matchedLanguage != null)
                    return matchedLanguage;
            }

            return null;
        }

        public ILanguage GetLanguage() => Language;
    }
}