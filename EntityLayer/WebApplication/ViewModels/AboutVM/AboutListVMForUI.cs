using EntityLayer.WebApplication.ViewModels.SocialMedia;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.AboutVM
{
    public class AboutListVMForUI
    {
        public string Header { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int Clients { get; set; }
        public int Projects { get; set; }
        public int HoursOfSupport { get; set; }
        public int HardWorkers { get; set; }

        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public IFormFile Photo { get; set; } = null!;
        public int SocialMediaId { get; set; }

        public SocialMediaAddVM SocialMedia { get; set; } = null!;
    }
}
