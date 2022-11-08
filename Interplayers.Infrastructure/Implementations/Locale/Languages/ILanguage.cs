using Interplayers.Domain.Messages.PasswordValidation;

namespace Interplayers.Infrastructure.Implementations.Locale
{
    public interface ILanguage
    {
        bool MatchesAcceptedLanguage(string acceptedLanguage);
        IPasswordValidationMessageLocale GetPasswordValidationMessageLocale();
    }
}