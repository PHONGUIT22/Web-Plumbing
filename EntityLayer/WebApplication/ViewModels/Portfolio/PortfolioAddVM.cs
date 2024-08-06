using EntityLayer.WebApplication.ViewModels.Category;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.Portfolio
{
    public class PortfolioAddVM
    {
        public string Title { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public IFormFile Photo { get; set; }= null!;
        public int CategoryId { get; set; }
        public CategoryAddVM Category { get; set; } = null!;
    }
}
