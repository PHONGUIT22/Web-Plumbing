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
    public class AboutConfig : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(x => x.CreateDate).IsRequired().HasMaxLength(10);

            builder.Property(x => x.UpdateDate).HasMaxLength(10);

            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();
            builder.Property(x => x.Header).IsRequired()
                .HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired()
                .HasMaxLength(5000);
            builder.Property(x => x.Clients).IsRequired()
                 .HasMaxLength(5);
            builder.Property(x => x.Projects).IsRequired()
                .HasMaxLength(5);
            builder.Property(x => x.HoursOfSupport).IsRequired()
                .HasMaxLength(5);
            builder.Property(x => x.HardWorkers).IsRequired()
                .HasMaxLength(5);
            builder.HasData(new About
            {
                Id = 1,
                Header = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                Description = "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                Clients = 5,
                Projects = 5,
                HoursOfSupport = 150,
                HardWorkers = 3,
                FileName = "test",
                FileType = "test",
                SocialMediaId = 1,
            });
        }
    }
}
