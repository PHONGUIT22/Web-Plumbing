using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.BaseEntities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual string CreateDate { get; set; } = null!;

        public virtual string? UpdateDate { get; set; }

        public virtual byte[] RowVersion { get; set; } = null!;
    }
}
