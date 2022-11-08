using Interplayers.Domain.ValueObjects;

namespace Interplayers.Domain.Messages.PasswordValidation
{
    public class PasswordRepeatedCharacterCountInvalidMessage : ISystemMessage, IPasswordValidationTranslatableMessage
    {
        public SystemMessageCode MessageCode { get; private set; }
        public readonly int MaximumRepetition;
        public readonly int BiggestRepetitionFound;
        
        public PasswordRepeatedCharacterCountInvalidMessage(int maximumRepetition, int biggestRepetitionFound)
        {
            this.MessageCode = new SystemMessageCode("PasswordRepeatedCharacterCountInvalidMessage");
            this.MaximumRepetition = maximumRepetition;
            this.BiggestRepetitionFound = biggestRepetitionFound;
        }

        public string GetDescription(IPasswordValidationMessageLocale locale) => locale.GetDescription(this);
    }
}