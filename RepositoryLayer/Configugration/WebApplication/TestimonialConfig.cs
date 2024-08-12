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
    public class TestimonialConfig : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.Property(x => x.CreateDate).IsRequired().HasMaxLength(10);

            builder.Property(x => x.UpdateDate).HasMaxLength(10);

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Comment).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Testimonial
            {
                Id = 1,
                Comment = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived n",
                Title = "interest",
                FullName = "DDD",
                FileName = "test",
                FileType = "test",
            }, new Testimonial
            {
                Id = 2,
                Comment = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived n",
                Title = "interest",
                FullName = "DDD2",
                FileName = "test",
                FileType = "test",
            }, new Testimonial
            {
                Id = 3,
                Comment = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. " +
                "It has survived n",
                Title = "interest",
                FullName = "DDD3",
                FileName = "test",
                FileType = "test",
            });
        }
    }
}
