using Interplayers.Domain.Messages.PasswordValidation;

namespace Interplayers.Infrastructure.Implementations.Locale.Languages.Portuguese
{
    public class PasswordValidationMessageLocalePortuguese : IPasswordValidationMessageLocale
    {
        public string GetDescription(PasswordCharacterCountInvalidMessage messageData) => $"Senha deve ter pelo menos {messageData.MinimumCount} caracteres";
        public string GetDescription(PasswordLowerLetterCountInvalidMessage messageData) => $"Senha deve ter pelo menos {messageData.MinimumCount} letras minúsculas";
        public string GetDescription(PasswordNumberCountInvalidMessage messageData) => $"Senha deve ter pelo menos {messageData.MinimumCount} números";
        public string GetDescription(PasswordRepeatedCharacterCountInvalidMessage messageData) => $"Não repita caracteres mais que {messageData.MaximumRepetition} vezes";
        public string GetDescription(PasswordSpecialCharacterCountInvalidMessage messageData) => $"Senha deve ter pelo menos {messageData.MinimumCount} caracteres especiais ({string.Join(string.Empty, messageData.SpecialCharacters)})";
        public string GetDescription(PasswordUpperLetterCountInvalidMessage messageData) => $"Senha deve ter pelo menos {messageData.MinimumCount} letras maiúsculas";
    }
}