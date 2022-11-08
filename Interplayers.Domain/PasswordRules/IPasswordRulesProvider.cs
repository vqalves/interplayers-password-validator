using System.Collections.Generic;

namespace Interplayers.Domain.PasswordRules
{
    public interface IPasswordRulesProvider
    {
        IEnumerable<IPasswordRule> GetRules();
    }
}
