using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interplayers.Domain.Messages.Validation
{
    public interface IValidationMessageLocale
    {
        string GetDescription(ValidationMessage message);
    }
}