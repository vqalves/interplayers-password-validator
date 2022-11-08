using System.Collections.Generic;

namespace Interplayers.Infrastructure.Implementations.PasswordRules
{
    public class PasswordRulesOptions
    {
        public static readonly string SectionName = "PasswordValidationOptions";

        public int? MinimumCharacterCount { get; set; }
        public int? MinimumAmountOfNumbers { get; set; }
        public int? MinimumAmountOfLowerCaseLetters { get; set; }
        public int? MinimumAmountOfUpperCaseLetters { get; set; }
        public int? MaximumAmountOfRepeatedCharacters { get; set; }

        public int? MinimumAmountOfSpecialCharacters { get; set; }
        public IEnumerable<char>? SpecialCharacters { get; set; }
    }
}