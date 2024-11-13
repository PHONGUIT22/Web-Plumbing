using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Identity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
namespace ServiceLayer.Middlewares.Identity
{
    public class SecurityStampCheck
    {
        private readonly RequestDelegate _next;

        public SecurityStampCheck(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, UserManager<AppUser> userManager)
        {
            if (context.User.Identity == null)
            {
                await _next(context);
                return;
            }
            if (context.User.Identity.IsAuthenticated) 
            {
                var ssCookie = context.User.Claims.FirstOrDefault(x => x.Type.Contains("SecurityStamp"))!.Value;
                var user = await userManager.GetUserAsync(context.User);
                if (ssCookie != user!.SecurityStamp)
                {
                    context.Response.Cookies.Delete("PlumbingCompany");
                    context.Response.Redirect("/Authentication/logIn?errorMessage=Your critical infomation has been changed." +
                        "Pls try login again");
                }
            }
            await _next(context);
            return;
        }

    }
}
