using Interplayers.Domain.Messages.PasswordValidation;
using Interplayers.Domain.ValueObjects;
using System;

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

        public bool TryValidate(Password password, out IPasswordValidationTranslatableMessage? invalidMessage)
        {
            var biggestRepetition = password.BiggestCharacterRepetition();

            if (biggestRepetition > MaximumAmountOfRepetition)
            {
                invalidMessage = new PasswordRepeatedCharacterCountInvalidMessage(MaximumAmountOfRepetition, biggestRepetition);
                return false;
            }

            invalidMessage = null;
            return true;
        }
    }
}