using Interplayers.Application.UseCases.ValidatePassword;
using Interplayers.WebAPI.Locale;
using Interplayers.WebAPI.Locale.ValidatePassword;
using Microsoft.AspNetCore.Mvc;

namespace Interplayers.WebAPI.Endpoints.ValidatePassword
{
    public sealed class ValidatePasswordEndpoint
    {
        private ValidatePasswordEndpoint() { }

        public static IResult Handle([FromServices]ILanguageDecider languageDecider, [FromServices]ValidatePasswordHandler handler, [FromBody]ValidatePasswordParameters parameter)
        {
            var useCaseData = parameter.ToUseCaseData();
            var result = handler.Handle(useCaseData);

            if (result.IsValid())
                return Results.StatusCode(200);

            var translator = languageDecider.GetLanguage().GetValidationMessageLocale();
            
            var response = new []
                {
                    new 
                    { 
                        attribute = nameof(parameter.Password), 
                        value = result.ErrorMessages.Select(x => translator.GetDescription(x))
                    }
                }
                .ToDictionary(x => x.attribute, x => x.value);
            
            return Results.Json(data: response, statusCode: 401);
        }
    }
}
