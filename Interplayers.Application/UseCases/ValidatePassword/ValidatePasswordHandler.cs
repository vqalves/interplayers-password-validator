using Interplayers.Domain.Messages.PasswordValidation;
using Interplayers.Domain.PasswordRules;
using Interplayers.Domain.ValueObjects;
using System.Collections.Generic;

namespace Interplayers.Application.UseCases.ValidatePassword
{
    public class ValidatePasswordHandler
    {
        private readonly IPasswordRulesProvider PasswordRulesProvider;

        public ValidatePasswordHandler(IPasswordRulesProvider passwordRulesProvider)
        {
            this.PasswordRulesProvider = passwordRulesProvider;
        }

        public ValidatePasswordResult Handle(ValidatePasswordData data)
        {
            var password = new Password(data.Password);

            var validationMessages = new List<IPasswordValidationTranslatableMessage>();

            foreach(var rule in PasswordRulesProvider.GetRules())
                if(!rule.TryValidate(password, out var message))
                    validationMessages.Add(message!);

            return new ValidatePasswordResult(validationMessages);
        }
    }
}