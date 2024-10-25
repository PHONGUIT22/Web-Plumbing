using CoreLayer.BaseEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Filters.WebApplication
{
    public class GenericAddAboutPreventationFilter<T> : IAsyncActionFilter where T : class, IBaseEntity, new()
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IToastNotification _toasty;

        public GenericAddAboutPreventationFilter(IToastNotification toasty, IUnitOfWorks unitOfWorks)
        {
            _toasty = toasty;
            _unitOfWorks = unitOfWorks;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var entityList = await _unitOfWorks.GetGenericRepository<T>().GetAllEntityList().ToListAsync(); 
            var methodName= typeof(T).Name;
            if (entityList.Any()) 
            {
                _toasty.AddErrorToastMessage($"You have an {methodName} section. Please delete and try again", new ToastrOptions { Title = "I am sorry" });
                context.Result = new RedirectToActionResult($"Get{methodName}List", methodName, new { Area = ("Admin") });
                return;
            }
            await next.Invoke();
            return;
        }
    }
}
