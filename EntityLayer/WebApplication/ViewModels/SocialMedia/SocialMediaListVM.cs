using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.SocialMedia
{
    public class SocialMediaListVM
    {
        public int Id { get; set; }
        public string CreateDate { get; set; } = null!;

        public string? UpdateDate { get; set; }
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public AboutListVM Abouts { get; set; } = null!;
    }
}
