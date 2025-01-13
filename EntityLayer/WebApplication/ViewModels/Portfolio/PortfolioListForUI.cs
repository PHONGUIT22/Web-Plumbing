using EntityLayer.WebApplication.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.Portfolio
{
    public class PortfolioListForUI
    {
        public string Title { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public CategoryListForUI Category { get; set; } = null!;
    }
}
