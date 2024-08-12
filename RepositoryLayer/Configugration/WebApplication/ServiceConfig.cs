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
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.CreateDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);
            builder.HasData(new Service
            {
                Id = 1,
                Icon = "bi-bi-facebook1",
                Name = "Plumbing service 1",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s" +
                ", when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived n",

            }, new Service
            {
                Id = 2,
                Icon = "bi-bi-facebook2",
                Name = "Plumbing service 1",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s" +
                ", when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived n",

            }, new Service
            {
                Id = 3,
                Icon = "bi-bi-facebook3",
                Name = "Plumbing service 1",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s" +
                ", when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived n",

            });
        }
    }
}
