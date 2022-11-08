using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interplayers.Domain.PasswordRules;
using Interplayers.Infrastructure.Implementations.PasswordRules;

namespace Interplayers.Tests.InfrastructureTests.ImplementationsTests
{
    public class PasswordRulesProviderTests
    {
        [Fact]
        public void PasswordRulesProviderTests_NoOptions_ReturnsNoRules()
        {
            var options = new PasswordRulesOptions();
            var provider = new PasswordRulesProvider(options);

            var rules = provider.GetRules();

            Assert.Empty(rules);
        }

        [Fact]
        public void PasswordRulesProviderTests_MinimumCharacterCount_ReturnsOneRule()
        {
            var options = new PasswordRulesOptions() { MinimumCharacterCount = 1 };
            var provider = new PasswordRulesProvider(options);

            var rules = provider.GetRules().ToList();

            Assert.Equal(1, rules.Count);
            Assert.IsType<PasswordCharacterCountRule>(rules[0]);
        }

        [Fact]
        public void PasswordRulesProviderTests_MinimumAmountOfNumbers_ReturnsOneRule()
        {
            var options = new PasswordRulesOptions() { MinimumAmountOfNumbers = 1 };
            var provider = new PasswordRulesProvider(options);

            var rules = provider.GetRules().ToList();

            Assert.Equal(1, rules.Count);
            Assert.IsType<PasswordNumberCountRule>(rules[0]);
        }

        [Fact]
        public void PasswordRulesProviderTests_MinimumAmountOfLowerCaseLetters_ReturnsOneRule()
        {
            var options = new PasswordRulesOptions() { MinimumAmountOfLowerCaseLetters = 1 };
            var provider = new PasswordRulesProvider(options);

            var rules = provider.GetRules().ToList();

            Assert.Equal(1, rules.Count);
            Assert.IsType<PasswordLowerLetterCountRule>(rules[0]);
        }

        [Fact]
        public void PasswordRulesProviderTests_MinimumAmountOfUpperCaseLetters_ReturnsOneRule()
        {
            var options = new PasswordRulesOptions() { MinimumAmountOfUpperCaseLetters = 1 };
            var provider = new PasswordRulesProvider(options);

            var rules = provider.GetRules().ToList();

            Assert.Equal(1, rules.Count);
            Assert.IsType<PasswordUpperLetterCountRule>(rules[0]);
        }

        [Fact]
        public void PasswordRulesProviderTests_MaximumAmountOfRepeatedCharacters_ReturnsOneRule()
        {
            var options = new PasswordRulesOptions() { MaximumAmountOfRepeatedCharacters = 1 };
            var provider = new PasswordRulesProvider(options);

            var rules = provider.GetRules().ToList();

            Assert.Equal(1, rules.Count);
            Assert.IsType<PasswordRepeatedCharacterCountRule>(rules[0]);
        }

        [Fact]
        public void PasswordRulesProviderTests_SpecialCharacters_HasMinimumAmountButNoList_ThrowsException()
        {
            var options = new PasswordRulesOptions() { MinimumAmountOfSpecialCharacters = 1 };
            
            Assert.Throws<ArgumentNullException>(() => new PasswordRulesProvider(options));
        }

        [Fact]
        public void PasswordRulesProviderTests_SpecialCharacters_HasListButNoMinimumAmount_ThrowsException()
        {
            var options = new PasswordRulesOptions() { SpecialCharacters = new char[0] };
            
            Assert.Throws<ArgumentNullException>(() => new PasswordRulesProvider(options));
        }

        [Fact]
        public void PasswordRulesProviderTests_SpecialCharacters_ReturnsOneRule()
        {
            var options = new PasswordRulesOptions() 
            { 
                MinimumAmountOfSpecialCharacters = 1, 
                SpecialCharacters = new char[] { '@' } 
            };

            var provider = new PasswordRulesProvider(options);

            var rules = provider.GetRules().ToList();

            Assert.Equal(1, rules.Count);
            Assert.IsType<PasswordSpecialCharacterCountRule>(rules[0]);
        }
    }
}