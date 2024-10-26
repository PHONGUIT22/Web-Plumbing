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

            services.AddScoped(typeof(GenericNotFoundFilter<About>));
            services.AddScoped(typeof(GenericNotFoundFilter<Category>));
            services.AddScoped(typeof(GenericNotFoundFilter<Contact>));
            services.AddScoped(typeof(GenericNotFoundFilter<HomePage>));
            services.AddScoped(typeof(GenericNotFoundFilter<Portfolio>));
            services.AddScoped(typeof(GenericNotFoundFilter<Service>));
            services.AddScoped(typeof(GenericNotFoundFilter<Team>));
            services.AddScoped(typeof(GenericNotFoundFilter<Testimonial>));
            return services;
        }
    }
}
