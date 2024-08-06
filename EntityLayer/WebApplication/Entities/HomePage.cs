using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.Entities
{
    public class HomePage : BaseEntity
    {
        
        public string Header { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string VideoLink { get; set; } = null!;
    }
}
