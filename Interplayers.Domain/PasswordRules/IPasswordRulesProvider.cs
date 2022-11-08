using System;
using System.Collections.Generic;
using System.Text;

namespace Interplayers.Domain.PasswordRules
{
    public interface IPasswordRulesProvider
    {
        IEnumerable<IPasswordRule> GetRules();
    }
}
