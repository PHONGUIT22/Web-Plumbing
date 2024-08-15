using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Messages.Identity
{
    public class IdentityMessages
    {
        public static string CheckEmailAddress()
        {
             return "Value should be in email format!";
        }
        public static string ComparePassword()
        {
            return "Password and Confirm Password must be same!";
        }
    }
}
