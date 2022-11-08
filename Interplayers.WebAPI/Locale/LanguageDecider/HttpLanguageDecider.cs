using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interplayers.WebAPI.Locale.Languages;

namespace Interplayers.WebAPI.Locale
{
    public class HttpLanguageDecider : ILanguageDecider
    {
        private Language Language;

        public HttpLanguageDecider(IHttpContextAccessor contextAcessor, LanguageProvider languageProvider)
        {
            var acceptedLanguages = contextAcessor.HttpContext!.Request.GetTypedHeaders().AcceptLanguage.OrderByDescending(x => x.Quality);

            // Select language based on the highest quality rating
            var languages = languageProvider.ListAllLanguages();
            foreach(var acceptedLanguage in acceptedLanguages)
            {
                var headerLanguage = acceptedLanguage.Value.Value;
                var matchedLanguage = languages.FirstOrDefault(x => x.MatchesAcceptedLanguage(headerLanguage));
                
                if(matchedLanguage != null)
                {
                    Language = matchedLanguage;
                    break;
                }
            }

            // If no language was select, pick the default language
            Language = Language ?? languageProvider.GetDefaultLanguage()!;
        }

        public Language GetLanguage() => Language;
    }
}