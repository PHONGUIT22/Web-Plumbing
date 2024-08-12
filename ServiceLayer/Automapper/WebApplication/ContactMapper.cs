using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<Contact, ContactListVM>().ReverseMap();
            CreateMap<Contact, ContactAddVM>().ReverseMap();
            CreateMap<Contact, ContactUpdateVM>().ReverseMap();
        }
    }
}
