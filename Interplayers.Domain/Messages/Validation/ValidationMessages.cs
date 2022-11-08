using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interplayers.Domain.Messages.Validation
{
    public class ValidationMessages
    {
        private static Dictionary<string, ValidationMessage> AllMessages = new Dictionary<string, ValidationMessage>();

        public static readonly ValidationMessage PasswordCharacterCountInvalid = RegisterMessage("PasswordCharacterCountInvalid");
        public static readonly ValidationMessage PasswordNumberCountInvalid = RegisterMessage("PasswordNumberCountInvalid");
        public static readonly ValidationMessage PasswordLowerLetterCountInvalid = RegisterMessage("PasswordLowerLetterCountInvalid");
        public static readonly ValidationMessage PasswordUpperLetterCountInvalid = RegisterMessage("PasswordUpperLetterCountInvalid");
        public static readonly ValidationMessage PasswordSpecialCharacterCountInvalid = RegisterMessage("PasswordSpecialCharacterCountInvalid");
        public static readonly ValidationMessage PasswordRepeatedCharacterCountInvalid = RegisterMessage("PasswordRepeatedCharacterCount");

        private static ValidationMessage RegisterMessage(string code)
        {
            var message = new ValidationMessage(code);
            
            if(AllMessages.ContainsKey(code))
                throw new ArgumentException($"A ValidationMessage with code {code} was already added in the dictionary");

            AllMessages.Add(code, message);
            return message;
        }

        public static IEnumerable<ValidationMessage> ListAll()
        {
            return AllMessages.Values;
        }
    }
}