using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.Testimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class TestimonialMapper : Profile
    {
        public TestimonialMapper()
        {
            CreateMap<Testimonial, TestimonialListVM>().ReverseMap();
            CreateMap<Testimonial, TestimonialAddVM>().ReverseMap();
            CreateMap<Testimonial, TestimonialUpdateVM>().ReverseMap();
            CreateMap<Testimonial, TestimonialListForUI>().ReverseMap();

        }
    }
}
