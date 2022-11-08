using Interplayers.Domain.Messages.PasswordValidation;
using Interplayers.Domain.ValueObjects;
using System;

namespace Interplayers.Domain.PasswordRules
{
    public class PasswordCharacterCountRule : IPasswordRule
    {
        private readonly int MinimumCharacterCount;

        public PasswordCharacterCountRule(int minimumCharacterCount)
        {
            this.MinimumCharacterCount = minimumCharacterCount;

            if(this.MinimumCharacterCount < 0)
                throw new ArgumentException("Minimum amount of characters cannot be less than zero");
        }

        public bool TryValidate(Password password, out IPasswordValidationTranslatableMessage? invalidMessage)
        {
            int amountOfCharacters = password.AmountOfCharacters();

            if(amountOfCharacters < MinimumCharacterCount)
            {
                invalidMessage = new PasswordCharacterCountInvalidMessage(MinimumCharacterCount, amountOfCharacters);
                return false;
            }

            invalidMessage = null;
            return true;
        }
    }
}