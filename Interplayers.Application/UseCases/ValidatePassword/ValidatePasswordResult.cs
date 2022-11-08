using Interplayers.Domain.Messages.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interplayers.Application.UseCases.ValidatePassword
{
    public class ValidatePasswordResult
    {
        public IEnumerable<ValidationMessage> ErrorMessages { get; private set; }

        public bool IsValid()
        {
            return !ErrorMessages.Any();
        }

        public ValidatePasswordResult(IEnumerable<ValidationMessage> errorMessages)
        {
            this.ErrorMessages = errorMessages;
        }
    }
}
