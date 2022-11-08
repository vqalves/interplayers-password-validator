using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interplayers.Infrastructure.Implementations.Locale.Languages
{
    public interface ILanguageProvider
    {
        IEnumerable<ILanguage> ListAllLanguages();
        ILanguage? GetDefaultLanguage();
        ILanguage? GetMatchedLanchage(string language);
    }
}