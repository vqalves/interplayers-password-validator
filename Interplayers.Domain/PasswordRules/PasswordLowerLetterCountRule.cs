using Interplayers.Domain.ValidationMessages;
using Interplayers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public bool TryValidate(Password password, out ValidationMessage? invalidMessage)
        {
            if (MinimumAmountOfLowerLetters > 0)
            {
                var lowerLetterCount = password.AmountOfLowerLetters();

                if (lowerLetterCount < MinimumAmountOfLowerLetters)
                {
                    invalidMessage = ValidationMessage.PasswordLowerLetterCountInvalid;
                    return false;
                }
            }

            invalidMessage = null;
            return true;
        }
    }
}