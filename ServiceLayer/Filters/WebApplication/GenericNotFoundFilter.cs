using CoreLayer.BaseEntities;
using Microsoft.AspNetCore.Mvc.Filters;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Exception.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Filters.WebApplication
{
    public class GenericNotFoundFilter<T> : IAsyncActionFilter where T : class, IBaseEntity, new()
    {
        private readonly IUnitOfWorks _unitOfWorks;
        public GenericNotFoundFilter(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var value = context.ActionArguments.FirstOrDefault().Value;
            if(value == null)
            {
                throw new ClientSideExceptions("The input is invalid. Please try to use valid ID");
            }
            var id = (int)value!;
            var entity = await _unitOfWorks.GetGenericRepository<T>().GetEntityByIdAsync(id);
            if (entity == null) 
            {
                throw new ClientSideExceptions("The Id does not exits. Please try to use exist ID");

            }
            await next.Invoke();
            return;
        }
    }
}
