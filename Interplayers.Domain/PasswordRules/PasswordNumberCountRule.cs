using Interplayers.Domain.Messages.PasswordValidation;
using Interplayers.Domain.ValueObjects;
using System;

namespace Interplayers.Domain.PasswordRules
{
    public class PasswordNumberCountRule : IPasswordRule
    {
        private readonly int MinimumAmountOfNumbers;

        public PasswordNumberCountRule(int minimumAmountOfNumbers)
        {
            this.MinimumAmountOfNumbers = minimumAmountOfNumbers;

            if(this.MinimumAmountOfNumbers < 0)
                throw new ArgumentException("Minimum amount of characters cannot be less than zero");
        }

        public bool TryValidate(Password password, out IPasswordValidationTranslatableMessage? invalidMessage)
        {
            if (MinimumAmountOfNumbers > 0)
            {
                var amountOfNumbers = password.AmountOfNumbers();

                if (amountOfNumbers < MinimumAmountOfNumbers)
                {
                    invalidMessage = new PasswordNumberCountInvalidMessage(MinimumAmountOfNumbers, amountOfNumbers);
                    return false;
                }
            }
            
            invalidMessage = null;
            return true;
        }
    }
}