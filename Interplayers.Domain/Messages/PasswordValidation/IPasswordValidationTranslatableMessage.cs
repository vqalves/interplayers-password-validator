namespace Interplayers.Domain.Messages.PasswordValidation
{
    public interface IPasswordValidationTranslatableMessage : ISystemMessage
    {
        string GetDescription(IPasswordValidationMessageLocale locale);
    }
}