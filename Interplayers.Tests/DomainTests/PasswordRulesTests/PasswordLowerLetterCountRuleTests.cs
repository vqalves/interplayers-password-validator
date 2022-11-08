using Interplayers.Domain.PasswordRules;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Tests.DomainTests.PasswordRulesTests
{
    public class PasswordLowerLetterCountRuleTests
    {
        [Fact]
        public void PasswordLowerLetterCountRule_RequiresZero_HasZero_ReturnsTrue()
        {
            var password = new Password(string.Empty);

            PasswordLowerLetterCountRule rule = new PasswordLowerLetterCountRule(0);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordLowerLetterCountRule_RequiresOne_HasZero_ReturnsFalse()
        {
            var password = new Password(string.Empty);

            PasswordLowerLetterCountRule rule = new PasswordLowerLetterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.False(result);
        }

        [Fact]
        public void PasswordLowerLetterCountRule_RequiresOne_HasOne_ReturnsTrue()
        {
            var password = new Password("a");

            PasswordLowerLetterCountRule rule = new PasswordLowerLetterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordLowerLetterCountRule_RequiresOne_HasTwo_ReturnsTrue()
        {
            var password = new Password("aa");

            PasswordLowerLetterCountRule rule = new PasswordLowerLetterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordLowerLetterCountRule_NegativeAmountParameter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new PasswordLowerLetterCountRule(-1));
        }
    }
}