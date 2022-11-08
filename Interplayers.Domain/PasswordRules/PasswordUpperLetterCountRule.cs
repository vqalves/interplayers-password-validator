using Interplayers.Domain.ValidationMessages;
using Interplayers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interplayers.Domain.PasswordRules
{
    public class PasswordUpperLetterCountRule : IPasswordRule
    {
        private readonly int MinimumAmountOfUpperLetters;

        public PasswordUpperLetterCountRule(int minimumAmountOfUpperLetters)
        {
            this.MinimumAmountOfUpperLetters = minimumAmountOfUpperLetters;

            if(this.MinimumAmountOfUpperLetters < 0)
                throw new ArgumentException("Minimum amount of characters cannot be less than zero");
        }

        public bool TryValidate(Password password, out ValidationMessage? invalidMessage)
        {
            if (MinimumAmountOfUpperLetters > 0)
            {
                var upperLetterCount = password.AmountOfUpperLetters();

                if (upperLetterCount < MinimumAmountOfUpperLetters)
                {
                    invalidMessage = ValidationMessage.PasswordUpperLetterCountInvalid;
                    return false;
                }
            }

            invalidMessage = null;
            return true;
        }
    }
}