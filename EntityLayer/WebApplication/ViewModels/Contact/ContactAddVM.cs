using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.Contact
{
    public class ContactAddVM
    {
        public string Location { get; set; } = null!;

        public string Email { get; set; } = null!;
        public string Call { get; set; } = null!;

        public string Map { get; set; } = null!;
    }
}
