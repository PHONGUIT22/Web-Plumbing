using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configugration.WebApplication
{
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.CreateDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Location).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Call).IsRequired().HasMaxLength(17);
            builder.Property(x => x.Map).IsRequired();

            builder.HasData(new Contact
            {
                Id = 1,
                CreateDate = "30/10/2024",

                Call = "123456666",
                Email = "t@try.com",
                Location = "Iron street, Brave .., Kd 2cf",
                Map = "TestLink Here",
            });
        }
    }
}
