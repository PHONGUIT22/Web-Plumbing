using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace Web.Plumbing.Components
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutListForUI = await _aboutService.GetAllListForUIAsync();
            return View(aboutListForUI);
        }
    }
}
