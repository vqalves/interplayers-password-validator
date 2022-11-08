using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interplayers.Domain.Messages.Validation;
using Interplayers.Infrastructure.Implementations.PasswordRules;
using Interplayers.WebAPI.Locale.Languages.English;

namespace Interplayers.WebAPI.Locale
{
    public abstract class Language
    {
        public abstract bool MatchesAcceptedLanguage(string acceptedLanguage);
        public abstract IValidationMessageLocale GetValidationMessageLocale();
    }
}