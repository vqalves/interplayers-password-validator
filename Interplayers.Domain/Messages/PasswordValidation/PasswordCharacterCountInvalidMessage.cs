using Interplayers.Domain.ValueObjects;

namespace Interplayers.Domain.Messages.PasswordValidation
{
    public class PasswordCharacterCountInvalidMessage : ISystemMessage, IPasswordValidationTranslatableMessage
    {
        public SystemMessageCode MessageCode { get; private set; }
        public readonly int MinimumCount;
        public readonly int CurrentCount;
        
        public PasswordCharacterCountInvalidMessage(int minimumCount, int currentCount)
        {
            this.MessageCode = new SystemMessageCode("PasswordCharacterCountInvalid");
            this.MinimumCount = minimumCount;
            this.CurrentCount = currentCount;
        }

        public string GetDescription(IPasswordValidationMessageLocale locale) => locale.GetDescription(this);
    }
}