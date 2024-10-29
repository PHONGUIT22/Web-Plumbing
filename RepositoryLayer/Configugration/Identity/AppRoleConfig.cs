using EntityLayer.Identity.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configugration.Identity
{
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole
            {
                Id = Guid.Parse("8C90791E-7C0C-4366-A315-6D51287C1C76").ToString(),
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            }, new AppRole
            {
                Id = Guid.Parse("BAD7CC85-8F42-4BF8-A0DB-1A078D18CE40").ToString(),
                Name = "MemBer",
                NormalizedName = "MEMBER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });
        }
    }
}
