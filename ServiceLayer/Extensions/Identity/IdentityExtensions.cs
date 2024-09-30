using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Context;
using ServiceLayer.Customization.Indentity.ErrorDescriber;
using ServiceLayer.Customization.Indentity.Validators;
using ServiceLayer.Helpers.Identity.EmailHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Extensions.Identity
{
    public static  class IdentityExtensions
    {
        public static IServiceCollection LoadIdentityExtensions(this IServiceCollection services, IConfiguration config)
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
                .AddDefaultTokenProviders()
                .AddErrorDescriber<LocalizationErrorDescriber>()
                .AddPasswordValidator<CustomPasswordValidator>()
                .AddUserValidator<CustomUserValidator>();
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
            services.Configure<DataProtectionTokenProviderOptions>(opt => 
            {
                opt.TokenLifespan = TimeSpan.FromMinutes(60);
            });
            services.AddScoped<IEmailSendMethod, EmailSendMethod>();
            services.Configure<GmailInformationsVM>(config.GetSection("EmailSettings"));
            return services;
        }
    }
}
