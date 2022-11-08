using Interplayers.Domain.Messages.PasswordValidation;
using Interplayers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interplayers.Domain.PasswordRules
{
    public class PasswordSpecialCharacterCountRule : IPasswordRule
    {
        private readonly int MinimumAmountOfSpecialCharacters;
        private readonly HashSet<char> SpecialCharacters;

        public PasswordSpecialCharacterCountRule(int minimumAmountOfSpecialCharacters, IEnumerable<char> specialCharacters)
        {
            this.MinimumAmountOfSpecialCharacters = minimumAmountOfSpecialCharacters;
            this.SpecialCharacters = new HashSet<char>(specialCharacters.Distinct());

            if(MinimumAmountOfSpecialCharacters < 0)
                throw new ArgumentException("Minimum amount of characters cannot be less than zero");

            if(MinimumAmountOfSpecialCharacters > 0 && !SpecialCharacters.Any())
                throw new ArgumentException("Cannot require special characters while providing an empty character list");
        }

        public bool TryValidate(Password password, out IPasswordValidationTranslatableMessage? invalidMessage)
        {
            if (MinimumAmountOfSpecialCharacters > 0)
            {
                var specialCharacterCount = password.AmountOfCharacters(x => SpecialCharacters.Contains(x));

                if (specialCharacterCount < MinimumAmountOfSpecialCharacters)
                {
                    invalidMessage = new PasswordSpecialCharacterCountInvalidMessage(MinimumAmountOfSpecialCharacters, specialCharacterCount, SpecialCharacters);
                    return false;
                }
            }

            invalidMessage = null;
            return true;
        }
    }
}