using Interplayers.Application.UseCases.ValidatePassword;
using Interplayers.Infrastructure.Implementations.Locale;
using Microsoft.AspNetCore.Mvc;

namespace Interplayers.WebAPI.Endpoints.ValidatePassword
{
    public sealed class ValidatePasswordResponseBody
    {
        private ValidatePasswordResponseBody() { }

        public static IResult Create200Result()
        {
            var body = new ValidatePasswordResponseBody_Result200();
            body.IsValid = true;
            
            return Results.Json(data: body, statusCode: 200);
        }

        public static IResult Create400Result(ILanguageDecider languageDecider, ValidatePasswordResult result)
        {
            var locale = languageDecider.GetLanguage().GetPasswordValidationMessageLocale();

            var messages = result.ErrorMessages.Select(x => x.GetDescription(locale));

            var body = new ValidatePasswordResponseBody_Result400();
            body.IsValid = false;
            body.Validations.Add(nameof(ValidatePasswordRequestData.Password), messages);
            
            return Results.Json(data: body, statusCode: 400);
        }

        public abstract class ValidatePasswordResponseBodyBase
        {
            public bool IsValid { get; set; }
        }

        public class ValidatePasswordResponseBody_Result200 : ValidatePasswordResponseBodyBase
        {
            
        }

        public class ValidatePasswordResponseBody_Result400 : ValidatePasswordResponseBodyBase
        {
            public Dictionary<string, IEnumerable<string>> Validations { get; set; }

            public ValidatePasswordResponseBody_Result400()
            {
                this.Validations = new Dictionary<string, IEnumerable<string>>();
            }
        }
    }
}
