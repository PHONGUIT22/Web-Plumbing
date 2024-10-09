using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Identity.Abstract
{
    public interface IAuthenticationMainService
    {
        Task CreateResetCredentialsAndSend(AppUser user, HttpContext context,IUrlHelper url, ForgotPasswordVM request);
    }
}
