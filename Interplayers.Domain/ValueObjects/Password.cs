using System;
using System.Linq;

namespace Interplayers.Domain.ValueObjects
{
    public class Password
    {
        public readonly string Value;

        public Password(string value)
        {
            this.Value = value;
        }

        public int AmountOfLowerLetters() => Value.Where(x => char.IsLetter(x) && char.IsLower(x)).Count();
        public int AmountOfUpperLetters() => Value.Where(x => char.IsLetter(x) && char.IsUpper(x)).Count();
        public int AmountOfNumbers() => Value.Where(x => char.IsNumber(x)).Count();

        public int AmountOfCharacters(Func<char, bool>? isCharacter = null)
        {
            if (isCharacter == null)
                return Value.Length;

            return Value.Where(isCharacter).Count();
        }

        public int BiggestCharacterRepetition()
        {
            if (Value.Length == 0)
                return 0;

            var highestSequence = CalculateCharacterSequence(0);
            var currentIndex = highestSequence;

            while(currentIndex < Value.Length)
            {
                var newSequence = CalculateCharacterSequence(currentIndex);
                currentIndex += newSequence;

                if (newSequence > highestSequence)
                    highestSequence = newSequence;
            }

            return highestSequence;
        }

        private int CalculateCharacterSequence(int originalIndex)
        {
            var currentIndex = originalIndex + 1;

            while(currentIndex < Value.Length && Value[currentIndex] == Value[originalIndex])
                currentIndex++;

            return currentIndex - originalIndex;
        }
    }
}
