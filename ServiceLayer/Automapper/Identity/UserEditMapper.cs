using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.Identity
{
    public class UserEditMapper : Profile
    {
        public UserEditMapper() 
        {
            CreateMap<AppUser,UserEditVM>().ReverseMap();
            CreateMap<AppUser,UserVM>().ReverseMap();
        }
    }
}
