namespace Interplayers.Domain.Messages.PasswordValidation
{
    public interface IPasswordValidationMessageLocale : 
        ISystemMessageTranslator<PasswordCharacterCountInvalidMessage>,
        ISystemMessageTranslator<PasswordLowerLetterCountInvalidMessage>,
        ISystemMessageTranslator<PasswordNumberCountInvalidMessage>,
        ISystemMessageTranslator<PasswordRepeatedCharacterCountInvalidMessage>,
        ISystemMessageTranslator<PasswordSpecialCharacterCountInvalidMessage>,
        ISystemMessageTranslator<PasswordUpperLetterCountInvalidMessage>
    {
        
    }
}