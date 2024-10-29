using EntityLayer.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configugration.Identity
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("506C3D14-6659-4821-84A1-658B2F27DA16").ToString(),
                RoleId = Guid.Parse("8C90791E-7C0C-4366-A315-6D51287C1C76").ToString()
            }, new AppUserRole
            {
                UserId= Guid.Parse("FB2BE674-DBFC-4226-8931-F382CBFE79C3").ToString(),
                RoleId = Guid.Parse("BAD7CC85-8F42-4BF8-A0DB-1A078D18CE40").ToString(),
            });
        }
    }
}
