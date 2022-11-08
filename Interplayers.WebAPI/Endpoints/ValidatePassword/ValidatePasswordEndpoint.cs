using Interplayers.Application.UseCases.ValidatePassword;
using Microsoft.AspNetCore.Mvc;

namespace Interplayers.WebAPI.Endpoints.ValidatePassword
{
    public sealed class ValidatePasswordEndpoint
    {
        private ValidatePasswordEndpoint() { }

        public static IResult Handle([FromServices]ValidatePasswordHandler handler, [FromBody]ValidatePasswordParameters parameter)
        {
            var useCaseData = parameter.ToUseCaseData();
            var result = handler.Handle(useCaseData);

            if (result.IsValid())
                return Results.StatusCode(200);

            var errors = new Dictionary<string, string[]>();
            errors.Add(nameof(parameter.Password), result.ErrorMessages.Select(x => x.Code).ToArray());

            return Results.ValidationProblem(statusCode: 401, errors: errors);
        }
    }
}
