using Interplayers.Application.UseCases.ValidatePassword;
using Interplayers.Infrastructure.Implementations.Locale;
using Microsoft.AspNetCore.Mvc;

namespace Interplayers.WebAPI.Endpoints.ValidatePassword
{
    public sealed class ValidatePasswordEndpoint
    {
        private ValidatePasswordEndpoint() { }

        public static IResult Handle([FromServices]ILanguageDecider languageDecider, [FromServices]ValidatePasswordHandler handler, [FromBody]ValidatePasswordRequestData parameter)
        {
            var useCaseData = parameter.ToUseCaseData();
            var result = handler.Handle(useCaseData);

            if (result.IsValid())
                return Results.StatusCode(200);

            var response = ValidatePasswordResponseBody.Create401(languageDecider, result);
            return Results.Json(data: response, statusCode: 401);
        }
    }
}
