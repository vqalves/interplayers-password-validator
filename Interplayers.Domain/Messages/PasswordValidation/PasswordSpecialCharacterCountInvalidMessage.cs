using System.Collections.Generic;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Domain.Messages.PasswordValidation
{
    public class PasswordSpecialCharacterCountInvalidMessage : ISystemMessage, IPasswordValidationTranslatableMessage
    {
        public SystemMessageCode MessageCode { get; private set; }
        public readonly int MinimumCount;
        public readonly int CurrentCount;
        public readonly IEnumerable<char> SpecialCharacters;
        
        public PasswordSpecialCharacterCountInvalidMessage(int minimumCount, int currentCount, IEnumerable<char> specialCharacters)
        {
            this.MessageCode = new SystemMessageCode("PasswordSpecialCharacterCountInvalidMessage");
            this.MinimumCount = minimumCount;
            this.CurrentCount = currentCount;
            this.SpecialCharacters = specialCharacters;
        }

        public string GetDescription(IPasswordValidationMessageLocale locale) => locale.GetDescription(this);
    }
}