using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<Portfolio> Portfolios { get; set; } = null!;

    }
}
