using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.Service
{
    public class ServiceListVM
    {
        public int Id { get; set; }
        public string CreateDate { get; set; } = DateTime.Now.ToString("d");

        public string? UpdateDate { get; set; }
        public string Name { get; set; } = null!;
        
    }
}
