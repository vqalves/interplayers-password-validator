using System;
using Interplayers.Domain.Messages.PasswordValidation;

namespace Interplayers.Infrastructure.Implementations.Locale.Languages.English
{
    public class LanguageEnglish : ILanguage
    {
        private readonly PasswordValidationMessageLocaleEnglish PasswordValidationMessageLocale;

        public LanguageEnglish()
        {
            this.PasswordValidationMessageLocale = new PasswordValidationMessageLocaleEnglish();
        }

        public IPasswordValidationMessageLocale GetPasswordValidationMessageLocale()
        {
            return PasswordValidationMessageLocale;
        }

        public bool MatchesAcceptedLanguage(string acceptedLanguage)
        {
            return acceptedLanguage.Contains("en", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}