using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.Portfolio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper
{
    public class PortfolioMapper : Profile
    {
        public PortfolioMapper()
        {
            CreateMap<Portfolio, PortfolioListVM>().ReverseMap();
            CreateMap<Portfolio, PortfolioAddVM>().ReverseMap();
            CreateMap<Portfolio, PortfolioUpdateVM>().ReverseMap();
        }
    }
}
