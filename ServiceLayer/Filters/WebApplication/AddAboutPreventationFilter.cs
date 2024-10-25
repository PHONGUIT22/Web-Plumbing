using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NToastNotify;
using ServiceLayer.Services.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Filters.WebApplication
{
    public class AddAboutPreventationFilter : IAsyncActionFilter
    {
        private readonly IAboutService _aboutService;
        private readonly IToastNotification _toasty;

        public AddAboutPreventationFilter(IAboutService aboutService, IToastNotification toasty)
        {
            _aboutService = aboutService;
            _toasty = toasty;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var aboutList = await _aboutService.GetAllListAsync();
            if (aboutList.Any()) 
            {
                _toasty.AddErrorToastMessage("You have an about section. Please delete and try again", new ToastrOptions { Title = "I am sorry" });
                context.Result = new RedirectToActionResult("GetAboutList", "About", new { Area = ("Admin") });
                return;
            }
            await next.Invoke();
            return;
        }
    }
}
