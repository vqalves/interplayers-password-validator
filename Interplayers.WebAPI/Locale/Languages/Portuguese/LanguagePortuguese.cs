using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interplayers.Domain.Messages.Validation;
using Interplayers.Infrastructure.Implementations.PasswordRules;
using Interplayers.WebAPI.Locale.ValidatePassword;

namespace Interplayers.WebAPI.Locale.Languages.English
{
    public class LanguagePortuguese : Language
    {
        private readonly PasswordRulesOptions PasswordRulesOptions;

        public LanguagePortuguese(PasswordRulesOptions passwordRulesOptions)
        {
            this.PasswordRulesOptions = passwordRulesOptions;
        }

        public override IValidationMessageLocale GetValidationMessageLocale()
        {
            return new ValidationMessageLocalePortuguese(PasswordRulesOptions);
        }

        public override bool MatchesAcceptedLanguage(string acceptedLanguage)
        {
            return acceptedLanguage.Contains("pt", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}