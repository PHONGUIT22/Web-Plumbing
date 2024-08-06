using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configugration
{
    public class PortfolioConfig : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(x => x.CreateDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdateDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();
            builder.HasData(new Portfolio
            {
                Id = 1,
                CategoryId = 1,
                FileName = "test",
                FileType = "test",
                Title = "test Picture",
            }, new Portfolio
            {
                Id = 2,
                CategoryId = 1,
                FileName = "test2",
                FileType = "test2",
                Title = "test Picture2",
            },new Portfolio
            {
                Id = 3,
                CategoryId = 2,
                FileName = "test3",
                FileType = "test3",
                Title = "test Picture3",
            }, new Portfolio
            {
                Id = 4,
                CategoryId = 2,
                FileName = "test4",
                FileType = "test4",
                Title = "test Picture4",
            });
        }
    }
}
