using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Messages.WebApplication
{
    public static class ValidationMessages
    {
        public static string NullEmptyMessage(string propName)
        {

          return $"{propName} must have a value!"; 

        }
        public static string MaximumCharacterAllowence(string propName,int restriction)
        {

            return $"{propName} can have maximum {restriction}";

        }
        public static string GreaterThanMessage(string propName, int restriction)
        {
            return $"{propName} must be greater than {restriction}";

        }
        public static string LessThanMessage(string propName, int restriction)
        {
            return $"{propName} must be less than {restriction}";

        }
    }
}
