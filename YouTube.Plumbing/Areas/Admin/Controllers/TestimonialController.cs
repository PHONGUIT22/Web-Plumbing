using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Category;
using EntityLayer.WebApplication.ViewModels.Testimonial;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Filters.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserver")]
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IValidator<TestimonialAddVM> _addValidator;
        private readonly IValidator<TestimonialUpdateVM> _updateValidator;

        public TestimonialController(ITestimonialService testimonialService, IValidator<TestimonialAddVM> addValidator, IValidator<TestimonialUpdateVM> updateValidator)
        {
            _testimonialService = testimonialService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> GetTestimonialList()
        {
            var testimonialList = await _testimonialService.GetAllListAsync();
            return View(testimonialList);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialAddVM request)
        {
            var validation = await _addValidator.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _testimonialService.AddTestimonialAsync(request);
                return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
            }
            validation.AddToModelState(this.ModelState);
            return View();
        }
        [ServiceFilter(typeof(GenericNotFoundFilter<Testimonial>))]
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _testimonialService.GetTestimonialById(id);
            return View(testimonial);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateVM request)
        {
            var validation = await _updateValidator.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _testimonialService.UpdateTestimonialAsync(request);
                return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
            }
            validation.AddToModelState(this.ModelState);
            return View();
        }
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
        }
    }
}
