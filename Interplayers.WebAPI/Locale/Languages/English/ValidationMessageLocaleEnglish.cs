using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interplayers.Domain.Messages.Validation;
using Interplayers.Infrastructure.Implementations.PasswordRules;

namespace Interplayers.WebAPI.Locale.ValidatePassword
{
    public class ValidationMessageLocaleEnglish : IValidationMessageLocale
    {
        private Dictionary<string, string> ValuesByMessageCode;
        
        public ValidationMessageLocaleEnglish(PasswordRulesOptions options)
        {
            this.ValuesByMessageCode = new Dictionary<string, string>();
            
            if(options.MinimumCharacterCount != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordCharacterCountInvalid.Code, $"Password must have at least {options.MinimumCharacterCount} characters");

            if(options.MinimumAmountOfNumbers != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordNumberCountInvalid.Code, $"Password must have at least {options.MinimumAmountOfNumbers} numbers");

            if(options.MinimumAmountOfLowerCaseLetters != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordLowerLetterCountInvalid.Code, $"Password must have at least {options.MinimumAmountOfLowerCaseLetters} lower case characters");

            if(options.MinimumAmountOfUpperCaseLetters != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordUpperLetterCountInvalid.Code, $"Password must have at least {options.MinimumAmountOfUpperCaseLetters} upper case characters");

            if(options.MinimumAmountOfSpecialCharacters != null && options.SpecialCharacters != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordSpecialCharacterCountInvalid.Code, $"Password must have at least {options.MinimumAmountOfSpecialCharacters} special characters ({string.Join(string.Empty, options.SpecialCharacters)})");

            if(options.MaximumAmountOfRepeatedCharacters != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordRepeatedCharacterCountInvalid.Code, $"Cannot repeat the same character more than {options.MaximumAmountOfRepeatedCharacters} times");
        }

        public string GetDescription(ValidationMessage message)
        {
            return ValuesByMessageCode[message.Code];
        }
    }
}