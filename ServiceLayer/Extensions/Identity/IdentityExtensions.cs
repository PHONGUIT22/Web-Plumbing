using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Extensions.Identity
{
    public static  class IdentityExtensions
    {
        public static IServiceCollection LoadIdentityExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 10;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredUniqueChars = 2;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
                opt.Lockout.MaxFailedAccessAttempts = 2;
            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(opt =>
            {
                var newCookie = new CookieBuilder();
                newCookie.Name = "PlumbingCompany";
                opt.LoginPath = new PathString("/Authentication/LogIn");
                opt.LogoutPath = new PathString("/Authentication/LogOut");
                opt.AccessDeniedPath = new PathString("/Authentication/AccessDenied");
                opt.Cookie = newCookie;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });
            return services;
        }
    }
}
