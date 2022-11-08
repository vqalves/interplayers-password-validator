using Interplayers.Domain.PasswordRules;
using Interplayers.Domain.ValueObjects;

namespace Interplayers.Tests.DomainTests.PasswordTests
{
    public class PasswordValueObjectTests
    {
        [Fact]
        public void PasswordValueObjectTests_AmountOfNumbers_HasZero_ReturnsZero()
        {
            Password password = new Password(string.Empty);
            var count = password.AmountOfNumbers();

            Assert.Equal(0, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfNumbers_HasOne_ReturnsOne()
        {
            Password password = new Password("1");
            var count = password.AmountOfNumbers();

            Assert.Equal(1, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfUpperLetters_HasOneUpper_ReturnsOne()
        {
            Password password = new Password("A");
            var count = password.AmountOfUpperLetters();

            Assert.Equal(1, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfUpperLetters_HasOneLower_ReturnsZero()
        {
            Password password = new Password("a");
            var count = password.AmountOfUpperLetters();

            Assert.Equal(0, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfUpperLetters_HasNoLetters_ReturnsZero()
        {
            Password password = new Password(string.Empty);
            var count = password.AmountOfUpperLetters();

            Assert.Equal(0, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfLowerLetters_HasOneUpper_ReturnsZero()
        {
            Password password = new Password("A");
            var count = password.AmountOfLowerLetters();

            Assert.Equal(0, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfLowerLetters_HasOneLower_ReturnsOne()
        {
            Password password = new Password("a");
            var count = password.AmountOfLowerLetters();

            Assert.Equal(1, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfLowerLetters_HasNoLetters_ReturnsZero()
        {
            Password password = new Password(string.Empty);
            var count = password.AmountOfLowerLetters();

            Assert.Equal(0, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfCharacters_ContainsTwoCharacters_ReturnsTwo()
        {
            Password password = new Password("aa");
            var count = password.AmountOfCharacters(x => x == 'a');

            Assert.Equal(2, count);
        }

        [Fact]
        public void PasswordValueObjectTests_AmountOfCharacters_DoesNotContainsCharacter_ReturnsZero()
        {
            Password password = new Password("aa");
            var count = password.AmountOfCharacters(x => x == 'b');

            Assert.Equal(0, count);
        }


        [Fact]
        public void PasswordValueObjectTests_BiggestCharacterRepetition_Empty_ReturnsZero()
        {
            Password password = new Password(string.Empty);
            var count = password.BiggestCharacterRepetition();

            Assert.Equal(0, count);
        }

        [Fact]
        public void PasswordValueObjectTests_BiggestCharacterRepetition_SingleCharacter_ReturnsCorrectValue()
        {
            Password password = new Password("a");
            var count = password.BiggestCharacterRepetition();

            Assert.Equal(1, count);
        }

        [Fact]
        public void PasswordValueObjectTests_BiggestCharacterRepetition_SingleSequence_ReturnsCorrectValue()
        {
            Password password = new Password("aaaaa");
            var count = password.BiggestCharacterRepetition();

            Assert.Equal(5, count);
        }

        [Fact]
        public void PasswordValueObjectTests_BiggestCharacterRepetition_TwoSequencesWithFirstLonger_ReturnsFirstSequence()
        {
            Password password = new Password("aaabb");
            var count = password.BiggestCharacterRepetition();

            Assert.Equal(3, count);
        }

        [Fact]
        public void PasswordValueObjectTests_BiggestCharacterRepetition_TwoSequencesWithSecondLonger_ReturnsSecondSequence()
        {
            Password password = new Password("aabbb");
            var count = password.BiggestCharacterRepetition();

            Assert.Equal(3, count);
        }
    }
}