using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Identity.ViewModels
{
    public class LogInVM
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
