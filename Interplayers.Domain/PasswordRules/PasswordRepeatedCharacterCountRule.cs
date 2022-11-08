using Interplayers.Domain.ValidationMessages;
using Interplayers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interplayers.Domain.PasswordRules
{
    public class PasswordRepeatedCharacterCountRule : IPasswordRule
    {
        private readonly int MaximumAmountOfRepetition;

        public PasswordRepeatedCharacterCountRule(int maximumAmountOfRepetition)
        {
            this.MaximumAmountOfRepetition = maximumAmountOfRepetition;

            if(this.MaximumAmountOfRepetition < 1)
                throw new ArgumentException("Maximum amount of character repetition cannot be less than one");
        }

        public bool TryValidate(Password password, out ValidationMessage? invalidMessage)
        {
            var biggestRepetition = password.BiggestCharacterRepetition();

            if (biggestRepetition > MaximumAmountOfRepetition)
            {
                invalidMessage = ValidationMessage.PasswordRepeatedCharacterCountInvalid;
                return false;
            }

            invalidMessage = null;
            return true;
        }
    }
}