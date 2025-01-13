using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Service, ServiceListVM>().ReverseMap();
            CreateMap<Service, ServiceAddVM>().ReverseMap();
            CreateMap<Service, ServiceUpdateVM>().ReverseMap();
            CreateMap<Service, ServiceListForUI>().ReverseMap(); 
        }
    }
}
