using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Exception.WebApplication
{
    public class ClientSideExceptions : System.Exception
    {
        public ClientSideExceptions(string? message) : base(message)
        {
        }
    }
}
