using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.Service
{
    public class ServiceAddVM
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string Icon { get; set; } = null!;
    }
}
