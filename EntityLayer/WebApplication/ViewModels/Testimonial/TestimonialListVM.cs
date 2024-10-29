using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.Testimonial
{
    public class TestimonialListVM
    {
        public int Id { get; set; }
        public string CreateDate { get; set; } = null!;

        public string? UpdateDate { get; set; }
        public string Comment { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
    }
}
