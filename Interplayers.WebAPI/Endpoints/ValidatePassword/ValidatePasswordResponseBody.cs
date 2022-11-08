using Interplayers.Application.UseCases.ValidatePassword;
using Interplayers.Infrastructure.Implementations.Locale;
using Microsoft.AspNetCore.Mvc;

namespace Interplayers.WebAPI.Endpoints.ValidatePassword
{
    public sealed class ValidatePasswordResponseBody
    {
        private ValidatePasswordResponseBody() { }

        public static ValidatePasswordResponseBody_Result401 Create401(ILanguageDecider languageDecider, ValidatePasswordResult result)
        {
            var locale = languageDecider.GetLanguage().GetPasswordValidationMessageLocale();

            var messages = result.ErrorMessages.Select(x => x.GetDescription(locale));

            var body = new ValidatePasswordResponseBody_Result401();
            body.Add(nameof(ValidatePasswordRequestData.Password), messages);
            return body;
        }

        public class ValidatePasswordResponseBody_Result401 : Dictionary<string, IEnumerable<string>>
        {
            
        }
    }
}
