using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Customization.Indentity.ErrorDescriber
{
    public class LocalizationErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresDigit()
        {
            return new() { Code = "NewDigitError", Description = "Please Use Digits" };

        }
        public override IdentityError PasswordRequiresLower()
        {
            return new() { Code = "NewLowerLetterError", Description = "Please Use Lower Letter" };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "NewTooShortError", Description="Your Password is short" };
        }
    }
}
