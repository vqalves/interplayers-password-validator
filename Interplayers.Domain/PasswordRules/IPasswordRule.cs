using Interplayers.Domain.Messages.PasswordValidation;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Domain.PasswordRules
{
    public interface IPasswordRule
    {
        bool TryValidate(Password password, out IPasswordValidationTranslatableMessage? invalidMessage); 
    }
}