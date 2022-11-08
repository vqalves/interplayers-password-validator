using Interplayers.Domain.Messages.PasswordValidation;

namespace Interplayers.Infrastructure.Implementations.Locale.Languages.English
{
    public class PasswordValidationMessageLocaleEnglish : IPasswordValidationMessageLocale
    {
        public string GetDescription(PasswordCharacterCountInvalidMessage messageData) => $"Password must have at least {messageData.MinimumCount} characters";
        public string GetDescription(PasswordLowerLetterCountInvalidMessage messageData) => $"Password must have at least {messageData.MinimumCount} lower case characters";
        public string GetDescription(PasswordNumberCountInvalidMessage messageData) => $"Password must have at least {messageData.MinimumCount} numbers";
        public string GetDescription(PasswordRepeatedCharacterCountInvalidMessage messageData) => $"Cannot repeat the same character more than {messageData.MaximumRepetition} times";
        public string GetDescription(PasswordSpecialCharacterCountInvalidMessage messageData) => $"Password must have at least {messageData.MinimumCount} special characters ({string.Join(string.Empty, messageData.SpecialCharacters)})";
        public string GetDescription(PasswordUpperLetterCountInvalidMessage messageData) => $"Password must have at least {messageData.MinimumCount} upper case characters";
    }
}