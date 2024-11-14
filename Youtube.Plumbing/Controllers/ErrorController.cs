using CoreLayer.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Exception.WebApplication;

namespace Web.Plumbing.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult GeneralExceptions()
        {
            var exceptions = HttpContext.Features.Get<IExceptionHandlerPathFeature>()!.Error;
            if (exceptions is ClientSideExceptions)
                return View(new ErrorVM(exceptions.Message,401));
            if(exceptions is DbUpdateConcurrencyException) 
                return View(new ErrorVM("Your data has been change, please try again",401));
            if(exceptions.InnerException is SqlException sqlException && sqlException.Number ==547)
                return View(new ErrorVM("You have to delete all relevant data before to move on",401));
            return View(new ErrorVM("SV error, contact to admin",500));
        }
        public IActionResult PageNotFound()
        {
            return View();
        } 
    }
}
