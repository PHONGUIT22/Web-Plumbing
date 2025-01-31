﻿using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configugration.WebApplication
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CreateDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasMany(x=>x.Portfolios).WithOne(x=>x.Category).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(new Category
            {
                Id = 1,
                CreateDate = "30/10/2024",

                Name = "Project",
            },
            new Category
            {
                Id = 2,
                CreateDate = "30/10/2024",

                Name = "SiteWorks",
            });
        }
    }
}
