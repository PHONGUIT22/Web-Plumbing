using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.SocialMedia
{
    public class SocialMediaUpdateVM
    {
        public int Id { get; set; }

        public string? UpdateDate { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public AboutUpdateVM Abouts { get; set; } = null!;
    }
}
