using System;
using Interplayers.Domain.Messages.PasswordValidation;

namespace Interplayers.Infrastructure.Implementations.Locale.Languages.Portuguese
{
    public class LanguagePortuguese : ILanguage
    {
        private readonly PasswordValidationMessageLocalePortuguese PasswordValidationMessageLocale;

        public LanguagePortuguese()
        {
            this.PasswordValidationMessageLocale = new PasswordValidationMessageLocalePortuguese();
        }

        public IPasswordValidationMessageLocale GetPasswordValidationMessageLocale()
        {
            return PasswordValidationMessageLocale;
        }

        public bool MatchesAcceptedLanguage(string acceptedLanguage)
        {
            return acceptedLanguage.Contains("pt", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}