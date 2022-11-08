using Interplayers.Application.UseCases.ValidatePassword;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.WebAPI.Endpoints.ValidatePassword
{
    public class ValidatePasswordRequestData
    {
        public string? Password { get; set; }

        public ValidatePasswordData ToUseCaseData()
        {
            return new ValidatePasswordData
            (
                password: Password ?? string.Empty
            );
        }
    }
}
