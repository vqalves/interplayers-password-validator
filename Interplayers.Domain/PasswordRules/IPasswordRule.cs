using Interplayers.Domain.Messages.Validation;
using Interplayers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interplayers.Domain.PasswordRules
{
    public interface IPasswordRule
    {
        bool TryValidate(Password password, out ValidationMessage? invalidMessage); 
    }
}