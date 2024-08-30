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
    public class LogInMapper : Profile
    {
       public LogInMapper() 
       { 
         CreateMap<AppUser,LogInVM>().ReverseMap();
       }
    }
}
