using System;
using System.Collections.Generic;
using System.Linq;
using Interplayers.Domain.PasswordRules;

namespace Interplayers.Infrastructure.Implementations.PasswordRules
{
    public class PasswordRulesProvider : IPasswordRulesProvider
    {
        private readonly PasswordRulesOptions Configuration;
        private readonly List<IPasswordRule> Rules;

        public PasswordRulesProvider(PasswordRulesOptions configuration)
        {
            this.Configuration = configuration;
            this.Rules = new List<IPasswordRule>();

            // Set rules
            if (Configuration.MinimumCharacterCount.HasValue)
                Rules.Add(new PasswordCharacterCountRule(Configuration.MinimumCharacterCount.Value));

            if (Configuration.MinimumAmountOfNumbers.HasValue)
                Rules.Add(new PasswordNumberCountRule(Configuration.MinimumAmountOfNumbers.Value));

            if (Configuration.MinimumAmountOfLowerCaseLetters.HasValue)
                Rules.Add(new PasswordLowerLetterCountRule(Configuration.MinimumAmountOfLowerCaseLetters.Value));

            if (Configuration.MinimumAmountOfUpperCaseLetters.HasValue)
                Rules.Add(new PasswordUpperLetterCountRule(Configuration.MinimumAmountOfUpperCaseLetters.Value));

            if (Configuration.MaximumAmountOfRepeatedCharacters.HasValue)
                Rules.Add(new PasswordRepeatedCharacterCountRule(Configuration.MaximumAmountOfRepeatedCharacters.Value));

            if (Configuration.MinimumAmountOfSpecialCharacters != null || Configuration.SpecialCharacters != null)
            {
                var parameters = new object?[] { Configuration.MinimumAmountOfSpecialCharacters, Configuration.SpecialCharacters };
                if(parameters.Any(x => x == null))
                    throw new ArgumentNullException($"PasswordRulesOptions {nameof(Configuration.MinimumAmountOfSpecialCharacters)} and {nameof(Configuration.SpecialCharacters)} must be provided simultaneously");

                Rules.Add(new PasswordSpecialCharacterCountRule(Configuration.MinimumAmountOfSpecialCharacters!.Value, Configuration.SpecialCharacters!));
            }
        }

        public IEnumerable<IPasswordRule> GetRules()
        {
            return Rules.AsEnumerable();
        }
    }
}