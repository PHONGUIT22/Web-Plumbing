using EntityLayer.WebApplication.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.Portfolio
{
    public class PortfolioListVM
    {
        public int Id { get; set; }
        public string CreateDate { get; set; } = null!;

        public string? UpdateDate { get; set; }
        public string Title { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public int CategoryId { get; set; }
        public CategoryListVM Category { get; set; } = null!;
    }
}
