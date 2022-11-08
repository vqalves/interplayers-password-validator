using Interplayers.Domain.ValidationMessages;
using Interplayers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

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

        public bool TryValidate(Password password, out ValidationMessage? invalidMessage)
        {
            if(password.AmountOfCharacters() < MinimumCharacterCount)
            {
                invalidMessage = ValidationMessage.PasswordCharacterCountInvalid;
                return false;
            }

            invalidMessage = null;
            return true;
        }
    }
}