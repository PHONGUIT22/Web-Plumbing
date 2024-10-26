using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Models
{
    public class ErrorVM
    {
        public ErrorVM(string errors, short statusCode)
        {
            Errors = new List<string> { errors };
            StatusCode = statusCode;
        }
        public ErrorVM(List<string> errors, short statusCode)
        {
            Errors = errors;
            StatusCode = statusCode;
        }

        public List<string> Errors { get; set; } = new List<string>();
        public short StatusCode { get; set; }

    }
}
