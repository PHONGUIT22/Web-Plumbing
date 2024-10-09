using Azure.Core;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.Identity.EmailHelper;
using ServiceLayer.Services.Identity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Identity.Concrete
{
    public class AuthenticationMainService : IAuthenticationMainService
    {
        private readonly IEmailSendMethod _email;
        private readonly UserManager<AppUser> _userManager;
        public AuthenticationMainService(IEmailSendMethod email, UserManager<AppUser> userManager)
        {
            _email = email;
            _userManager = userManager;
        }

        public async Task CreateResetCredentialsAndSend(AppUser user, HttpContext context, IUrlHelper url, ForgotPasswordVM request)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = url.Action("ResetPassword", "Authentication", new { userId = user.Id, token = resetToken }, context.Request.Scheme);

            await _email.SendPasswordResetLinkWithToken(passwordResetLink!, request.Email);
        }
    }
}
