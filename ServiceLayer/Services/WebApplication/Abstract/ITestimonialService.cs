using EntityLayer.WebApplication.ViewModels.Testimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface ITestimonialService
    {
        Task<List<TestimonialListVM>> GetAllListAsync();
        Task AddTestimonialAsync(TestimonialAddVM request);
        Task DeleteTestimonialAsync(int id);
        Task<TestimonialUpdateVM> GetTestimonialById(int id);
        Task UpdateTestimonialAsync(TestimonialUpdateVM request);
    }
}
