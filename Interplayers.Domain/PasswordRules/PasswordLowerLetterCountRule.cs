using Interplayers.Domain.Messages.PasswordValidation;
using Interplayers.Domain.ValueObjects;
using System;

namespace Interplayers.Domain.PasswordRules
{
    public class PasswordLowerLetterCountRule : IPasswordRule
    {
        private readonly int MinimumAmountOfLowerLetters;

        public PasswordLowerLetterCountRule(int minimumAmountOfLowerLetters)
        {
            this.MinimumAmountOfLowerLetters = minimumAmountOfLowerLetters;

            if(this.MinimumAmountOfLowerLetters < 0)
                throw new ArgumentException("Minimum amount of characters cannot be less than zero");
        }

        public bool TryValidate(Password password, out IPasswordValidationTranslatableMessage? invalidMessage)
        {
            if (MinimumAmountOfLowerLetters > 0)
            {
                var lowerLetterCount = password.AmountOfLowerLetters();

                if (lowerLetterCount < MinimumAmountOfLowerLetters)
                {
                    invalidMessage = new PasswordLowerLetterCountInvalidMessage(MinimumAmountOfLowerLetters, lowerLetterCount);
                    return false;
                }
            }

            invalidMessage = null;
            return true;
        }
    }
}