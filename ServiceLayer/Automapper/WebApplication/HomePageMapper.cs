using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class HomePageMapper : Profile
    {
        public HomePageMapper()
        {
            CreateMap<HomePage, HomePageListVM>().ReverseMap();
            CreateMap<HomePage, HomePageAddVM>().ReverseMap();
            CreateMap<HomePage, HomePageUpdateVM>().ReverseMap();
        }
    }
}
