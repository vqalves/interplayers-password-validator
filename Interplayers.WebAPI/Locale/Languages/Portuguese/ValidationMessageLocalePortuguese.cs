using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interplayers.Domain.Messages.Validation;
using Interplayers.Infrastructure.Implementations.PasswordRules;

namespace Interplayers.WebAPI.Locale.ValidatePassword
{
    public class ValidationMessageLocalePortuguese : IValidationMessageLocale
    {
        private Dictionary<string, string> ValuesByMessageCode;

        public ValidationMessageLocalePortuguese(PasswordRulesOptions options)
        {
            this.ValuesByMessageCode = new Dictionary<string, string>();
            
            if(options.MinimumCharacterCount != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordCharacterCountInvalid.Code, $"Senha deve ter pelo menos {options.MinimumCharacterCount} caracteres");

            if(options.MinimumAmountOfNumbers != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordNumberCountInvalid.Code, $"Senha deve ter pelo menos {options.MinimumAmountOfNumbers} números");

            if(options.MinimumAmountOfLowerCaseLetters != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordLowerLetterCountInvalid.Code, $"Senha deve ter pelo menos {options.MinimumAmountOfLowerCaseLetters} letras minúsculas");

            if(options.MinimumAmountOfUpperCaseLetters != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordUpperLetterCountInvalid.Code, $"Senha deve ter pelo menos {options.MinimumAmountOfUpperCaseLetters} letras maiúsculas");

            if(options.MinimumAmountOfSpecialCharacters != null && options.SpecialCharacters != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordSpecialCharacterCountInvalid.Code, $"Senha deve ter pelo menos {options.MinimumAmountOfSpecialCharacters} caracteres especiais ({string.Join(string.Empty, options.SpecialCharacters)})");

            if(options.MaximumAmountOfRepeatedCharacters != null)
                ValuesByMessageCode.Add(ValidationMessages.PasswordRepeatedCharacterCountInvalid.Code, $"Não repita caracteres mais que {options.MaximumAmountOfRepeatedCharacters} vezes");
        }

        public string GetDescription(ValidationMessage message)
        {
            return ValuesByMessageCode[message.Code];
        }
    }
}