using Interplayers.Domain.PasswordRules;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Tests.DomainTests.PasswordRulesTests
{
    public class PasswordUpperLetterCountRuleTests
    {
        [Fact]
        public void PasswordUpperLetterCountRule_RequiresZero_HasZero_ReturnsTrue()
        {
            var password = new Password(string.Empty);

            PasswordUpperLetterCountRule rule = new PasswordUpperLetterCountRule(0);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordUpperLetterCountRule_RequiresOne_HasZero_ReturnsFalse()
        {
            var password = new Password(string.Empty);

            PasswordUpperLetterCountRule rule = new PasswordUpperLetterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.False(result);
        }

        [Fact]
        public void PasswordUpperLetterCountRule_RequiresOne_HasOne_ReturnsTrue()
        {
            var password = new Password("A");

            PasswordUpperLetterCountRule rule = new PasswordUpperLetterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordUpperLetterCountRule_RequiresOne_HasTwo_ReturnsTrue()
        {
            var password = new Password("AA");

            PasswordUpperLetterCountRule rule = new PasswordUpperLetterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordUpperLetterCountRule_NegativeAmountParameter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new PasswordUpperLetterCountRule(-1));
        }
    }
}