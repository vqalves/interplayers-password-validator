using Interplayers.Domain.PasswordRules;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Tests.DomainTests.PasswordRulesTests
{
    public class PasswordRepeatedCharacterCountRuleTests
    {
        [Fact]
        public void PasswordRepeatedCharacterCountRule_MaximumSequenceOfOne_NonRepetitive_ReturnsTrue()
        {
            var password = new Password("abc");

            PasswordRepeatedCharacterCountRule rule = new PasswordRepeatedCharacterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordRepeatedCharacterCountRule_MaximumSequenceOfOne_TwoRepetitions_ReturnsFalse()
        {
            var password = new Password("aabbcc");

            PasswordRepeatedCharacterCountRule rule = new PasswordRepeatedCharacterCountRule(1);
            var result = rule.TryValidate(password, out var message);

            Assert.False(result);
        }

        [Fact]
        public void PasswordRepeatedCharacterCountRule_MaximumSequenceOfTwo_TwoRepetitions_ReturnsTrue()
        {
            var password = new Password("aabbcc");

            PasswordRepeatedCharacterCountRule rule = new PasswordRepeatedCharacterCountRule(2);
            var result = rule.TryValidate(password, out var message);

            Assert.True(result);
        }

        [Fact]
        public void PasswordRepeatedCharacterCountRule_ZeroAmountParameter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new PasswordRepeatedCharacterCountRule(0));
        }

        [Fact]
        public void PasswordRepeatedCharacterCountRule_NegativeAmountParameter_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new PasswordRepeatedCharacterCountRule(-1));
        }
    }
}