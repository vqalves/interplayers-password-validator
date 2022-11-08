using System;
using System.Collections.Generic;

namespace Interplayers.Domain.Messages.Validation
{
    public class ValidationMessage
    {
        public readonly string Code;

        internal ValidationMessage(string code)
        {
            this.Code = code;
        }

        public string GetDescription(IValidationMessageLocale locale) => locale.GetDescription(this);
    }
}