using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.SocialMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper
{
    public class SocialMediaMapper : Profile
    {
        public SocialMediaMapper()
        {
            CreateMap<SocialMedia, SocialMediaListVM>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaAddVM>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaUpdateVM>().ReverseMap();
        }
    }
}
