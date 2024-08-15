using EntityLayer.Identity.Entities;
using EntityLayer.WebApplication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole,string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public AppDbContext() 
        { 
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HomePage> HomePages { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /*modelBuilder.Entity<About>().Property(x => x.Description).IsRequired().HasMaxLength(200);*/
            base.OnModelCreating(modelBuilder);
        }
    }
}
