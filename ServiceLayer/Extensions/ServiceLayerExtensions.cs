using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ServiceLayer.Services.WebApplication.Abstract;
using FluentValidation.AspNetCore;
using FluentValidation;
using ServiceLayer.FluentValidation.WebApplication.HomePageValidation;
using ServiceLayer.Extensions.Identity;
using Microsoft.Extensions.Configuration;

namespace ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.LoadIdentityExtensions(config);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Service"));
            foreach (var serviceType in types)
            {
                var isServiceType = serviceType.GetInterfaces().FirstOrDefault(x => x.Name == $"I{serviceType.Name}");
                if (isServiceType != null)
                {
                    services.AddScoped(isServiceType, serviceType);
                }
            }
            services.AddFluentValidationAutoValidation(opt =>
            {
                opt.DisableDataAnnotationsValidation=true;
            });
            services.AddValidatorsFromAssemblyContaining<HomePageAddValidation>();
            return services;
        }
    }
}
