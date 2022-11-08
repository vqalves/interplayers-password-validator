using Interplayers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interplayers.Application.UseCases.ValidatePassword
{
    public class ValidatePasswordData
    {
        public string Password { get; private set; }

        public ValidatePasswordData(string password)
        {
            this.Password = password;
        }
    }
}
