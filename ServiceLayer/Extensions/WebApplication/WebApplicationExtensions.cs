using EntityLayer.WebApplication.Entities;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Filters.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Extensions.WebApplication
{
    public static class WebApplicationExtensions
    {
        public static IServiceCollection LoadWebApplicationExtensions(this IServiceCollection services)
        {
            services.AddScoped(typeof(GenericAddAboutPreventationFilter<About>));
            services.AddScoped(typeof(GenericAddAboutPreventationFilter<Contact>));
           

            return services;
        }
    }
}
