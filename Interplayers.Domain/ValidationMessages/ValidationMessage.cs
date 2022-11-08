using System;

namespace Interplayers.Domain.ValidationMessages
{
    public class ValidationMessage
    {
        public static readonly ValidationMessage PasswordCharacterCountInvalid = new ValidationMessage("PasswordCharacterCountInvalid");
        public static readonly ValidationMessage PasswordNumberCountInvalid = new ValidationMessage("PasswordNumberCountInvalid");
        public static readonly ValidationMessage PasswordLowerLetterCountInvalid = new ValidationMessage("PasswordLowerLetterCountInvalid");
        public static readonly ValidationMessage PasswordUpperLetterCountInvalid = new ValidationMessage("PasswordUpperLetterCountInvalid");
        public static readonly ValidationMessage PasswordSpecialCharacterCountInvalid = new ValidationMessage("PasswordSpecialCharacterCountInvalid");
        public static readonly ValidationMessage PasswordRepeatedCharacterCountInvalid = new ValidationMessage("PasswordRepeatedCharacterCount");
        
        public readonly string Code;

        private ValidationMessage(string code)
        {
            this.Code = code;
        }
    }
}