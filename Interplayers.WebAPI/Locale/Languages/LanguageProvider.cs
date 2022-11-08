using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interplayers.Infrastructure.Implementations.PasswordRules;
using Interplayers.WebAPI.Locale.Languages.English;

namespace Interplayers.WebAPI.Locale.Languages
{
    public class LanguageProvider
    {
        private readonly List<Language> Languages;
        private Language? DefaultLanguage;

        public LanguageProvider()
        {
            this.Languages = new List<Language>();
            this.DefaultLanguage = null;
        }

        public IEnumerable<Language> ListAllLanguages()
        {
            return Languages.AsEnumerable();
        }

        public Language? GetDefaultLanguage()
        {
            return DefaultLanguage;
        }

        public void RegisterLanguage(Language language, bool setAsDefault)
        {
            this.Languages.Add(language);
            
            if(DefaultLanguage == null || setAsDefault)
                DefaultLanguage = language;
        }

        internal static LanguageProvider Create(IServiceProvider c)
        {
            var passwordRulesOptions = c.GetService<PasswordRulesOptions>()!;

            var languageProvider = new LanguageProvider();
            languageProvider.RegisterLanguage(new LanguageEnglish(passwordRulesOptions), true);
            languageProvider.RegisterLanguage(new LanguagePortuguese(passwordRulesOptions), false);
            
            return languageProvider;
        }
    }
}