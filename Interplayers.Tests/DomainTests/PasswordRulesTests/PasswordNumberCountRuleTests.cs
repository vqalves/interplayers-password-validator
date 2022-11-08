using Interplayers.Domain.PasswordRules;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Tests.DomainTests.PasswordRulesTests
{
    public class PasswordNumberCountRuleTests
    {
        [Fact]
        public void PasswordNumberCountRule_RequiresZero_HasZero_ReturnsTrue()
        {
            var password = new Password("a");

            PasswordNumberCountRule rule = new PasswordNumberCountRule(0);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordNumberCountRule_RequiresOne_HasZero_ReturnsFalse()
        {
            var password = new Password("a");

            PasswordNumberCountRule rule = new PasswordNumberCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.False(result);
        }

        [Fact]
        public void PasswordNumberCountRule_RequiresOne_HasOne_ReturnsTrue()
        {
            var password = new Password("a2");

            PasswordNumberCountRule rule = new PasswordNumberCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordNumberCountRule_RequiresOne_HasTwo_ReturnsTrue()
        {
            var password = new Password("a22");

            PasswordNumberCountRule rule = new PasswordNumberCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordNumberCountRule_AllPossibleNumbers_ReturnsTrue()
        {
            var password = new Password("0123456789");

            PasswordNumberCountRule rule = new PasswordNumberCountRule(password.AmountOfCharacters());
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordNumberCountRule_NegativeAmountParameter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new PasswordNumberCountRule(-1));
        }
    }
}