using Interplayers.Domain.Messages.PasswordValidation;
using System.Collections.Generic;
using System.Linq;

namespace Interplayers.Application.UseCases.ValidatePassword
{
    public class ValidatePasswordResult
    {
        public IEnumerable<IPasswordValidationTranslatableMessage> ErrorMessages { get; private set; }

        public bool IsValid()
        {
            return !ErrorMessages.Any();
        }

        public ValidatePasswordResult(IEnumerable<IPasswordValidationTranslatableMessage> errorMessages)
        {
            this.ErrorMessages = errorMessages;
        }
    }
}
