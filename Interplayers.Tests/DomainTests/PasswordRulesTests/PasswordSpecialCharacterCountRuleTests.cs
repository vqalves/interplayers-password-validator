using Interplayers.Domain.PasswordRules;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Tests.DomainTests.PasswordRulesTests
{
    public class PasswordSpecialCharacterCountRuleTests
    {
        private char[] SpecialCharacters = new char[] { '@' };

        [Fact]
        public void PasswordSpecialCharacterCountRule_RequiresZero_HasZero_ReturnsTrue()
        {
            var password = new Password(string.Empty);

            PasswordSpecialCharacterCountRule rule = new PasswordSpecialCharacterCountRule(0, SpecialCharacters);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordSpecialCharacterCountRule_RequiresOne_HasZero_ReturnsFalse()
        {
            var password = new Password(string.Empty);

            PasswordSpecialCharacterCountRule rule = new PasswordSpecialCharacterCountRule(1, SpecialCharacters);
            var result = rule.TryValidate(password, out var message);

            Assert.False(result);
        }

        [Fact]
        public void PasswordSpecialCharacterCountRule_RequiresOne_HasOne_ReturnsTrue()
        {
            var password = new Password("@");

            PasswordSpecialCharacterCountRule rule = new PasswordSpecialCharacterCountRule(1, SpecialCharacters);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordSpecialCharacterCountRule_RequiresOne_HasTwo_ReturnsTrue()
        {
            var password = new Password("@@");

            PasswordSpecialCharacterCountRule rule = new PasswordSpecialCharacterCountRule(1, SpecialCharacters);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordSpecialCharacterCountRule_NegativeAmountParameter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new PasswordSpecialCharacterCountRule(-1, SpecialCharacters));
        }

        [Fact]
        public void PasswordSpecialCharacterCountRule_PositiveAmountAndEmptyListParameters_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new PasswordSpecialCharacterCountRule(1, new char[0]));
        }
    }
}