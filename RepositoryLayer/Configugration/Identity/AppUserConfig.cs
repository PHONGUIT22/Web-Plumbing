using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configugration.Identity
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var admin = new AppUser
            {
                Id = Guid.Parse("506C3D14-6659-4821-84A1-658B2F27DA16").ToString(),
                Email = "np79857@gmail.com",
                NormalizedEmail = "NP79857@GMAIL.COM",
                UserName = "phong",
                NormalizedUserName = "PHONG",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),

            };
            var adminPasswordHash = PasswordHash(admin, "domdomyesfF@1");
            admin.PasswordHash = adminPasswordHash;
            builder.HasData(admin);
            var member = new AppUser
            {
                Id = Guid.Parse("FB2BE674-DBFC-4226-8931-F382CBFE79C3").ToString(),
                Email = "np79856@gmail.com",
                NormalizedEmail = "NP79856@GMAIL.COM",
                UserName = "phongmember",
                NormalizedUserName = "PHONGMEMBER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),

            };
            var memberPasswordHash = PasswordHash(member, "domdomyesfF@1");
            member.PasswordHash = memberPasswordHash;
            builder.HasData(member);
        }
        private string PasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
