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
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.CreateDate).IsRequired().HasMaxLength(10);

            builder.Property(x => x.UpdateDate).HasMaxLength(10);

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Team
            {
                Id = 1,
                CreateDate = "30/10/2024",

                FullName = "Phong",
                Title = "Professso",
                FaceBook = "facebook",
                Instagram = "Insta",
                FileName = "test",
                FileType = "test",
            });
        }
    }
}
