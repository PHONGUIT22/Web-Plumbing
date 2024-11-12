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
    public class AppUserClaimConfig : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.HasData(new AppUserClaim
            {
                Id = 1,
                UserId = Guid.Parse("FB2BE674-DBFC-4226-8931-F382CBFE79C3").ToString(),
                ClaimType = "AdminObserverExpireDate",
                ClaimValue = "11/11/2024"
            });
        }
    }
}
