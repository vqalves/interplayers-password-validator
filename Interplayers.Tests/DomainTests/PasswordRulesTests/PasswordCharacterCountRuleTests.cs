using Interplayers.Domain.PasswordRules;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Tests.DomainTests.PasswordRulesTests
{
    public class PasswordValueObjectTests
    {
        [Fact]
        public void PasswordCharacterCountRule_RequiresZero_HasZero_ReturnsTrue()
        {
            var password = new Password(string.Empty);

            PasswordCharacterCountRule rule = new PasswordCharacterCountRule(0);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordCharacterCountRule_RequiresOne_HasZero_ReturnsFalse()
        {
            var password = new Password(string.Empty);

            PasswordCharacterCountRule rule = new PasswordCharacterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.False(result);
        }

        [Fact]
        public void PasswordCharacterCountRule_RequiresOne_HasOne_ReturnsTrue()
        {
            var password = new Password("a");

            PasswordCharacterCountRule rule = new PasswordCharacterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordCharacterCountRule_RequiresOne_HasTwo_ReturnsTrue()
        {
            var password = new Password("aa");

            PasswordCharacterCountRule rule = new PasswordCharacterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordLowerLetterCountRule_NegativeAmountParameter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new PasswordCharacterCountRule(-1));
        }
    }
}