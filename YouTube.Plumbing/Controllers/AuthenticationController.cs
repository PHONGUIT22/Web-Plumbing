using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ServiceLayer.Helpers.Identity.EmailHelper;
using ServiceLayer.Helpers.Identity.ModelStateHelper;
namespace YouTube.Plumbing.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IValidator<SignUpVM> _signUpValidator;
        private readonly IValidator<LogInVM> _logInValidator;
        private readonly IValidator<ForgotPasswordVM> _forgotPasswordValidator;
        private readonly IValidator<ResetPasswordVM> _resetPasswordValidator;
        private readonly IMapper _iMapper;
        private readonly IEmailSendMethod _emailSendMethod;

        public AuthenticationController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IValidator<SignUpVM> signUpValidator, IValidator<LogInVM> logInValidator, IValidator<ForgotPasswordVM> forgotPasswordValidator, IMapper iMapper, IEmailSendMethod emailSendMethod, IValidator<ResetPasswordVM> resetPasswordValidator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signUpValidator = signUpValidator;
            _logInValidator = logInValidator;
            _forgotPasswordValidator = forgotPasswordValidator;
            _iMapper = iMapper;
            _emailSendMethod = emailSendMethod;
            _resetPasswordValidator = resetPasswordValidator;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM request)
        {
            var validation = await _signUpValidator.ValidateAsync(request);
            if(!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }
            var user = _iMapper.Map<AppUser>(request);
            var userCreateResult = await _userManager.CreateAsync(user, request.Password);
            if (!userCreateResult.Succeeded) 
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorList(userCreateResult.Errors);
                return View();
            }
            return RedirectToAction("LogIn", "Authentication");
        }


        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl=null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Dashboard", new { Area = "Admin" });
            var validation = await _logInValidator.ValidateAsync(request);
            if (!validation.IsValid) 
            {
                
                validation.AddToModelState(this.ModelState);
                return View();
            }
            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null) 
            {
                ViewBag.Result = "NotSucced";
                ModelState.AddModelErrorList(new List<string> { "Email or Password is wrong" });
                return View();
            }
            var logInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);
            if(logInResult.Succeeded)
            {
                return Redirect(returnUrl!);
            }
            if(logInResult.IsLockedOut)
            {
                ViewBag.Result = "LockedOut";
                ModelState.AddModelErrorList(new List<string> { "Your Account Is Locked Out for 60s!" });
                return View();
            }
            ViewBag.Result = "FailedAttempt";
            ModelState.AddModelErrorList(new List<string> { $"Email or Password is wrong! Fail attempt{await _userManager.GetAccessFailedCountAsync(hasUser)}" });
            return View();
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM request)
        {
            var validation = await _forgotPasswordValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();

            }
            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "UserDoesNotExit";
                ModelState.AddModelErrorList(new List<string> { "User does not exit!" });
                return View();
            }
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);
            var passwordResetLink = Url.Action("ResetPassword", "Authentication", new { userId = hasUser.Id, token = resetToken},HttpContext.Request.Scheme);

            await _emailSendMethod.SendPasswordResetLinkWithToken(passwordResetLink!, request.Email);
            return RedirectToAction("LogIn", "Authentication");
        }
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token, List<string> errors)
        {
            TempData["UserId"] = userId;
            TempData["Token"] = token;
            if (errors.Any())
            {
                ViewBag.Result = "Error";
                ModelState.AddModelErrorList(errors);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM request)
        {
            var userId = TempData["UserId"];
            var token = TempData["Token"];
            if(userId == null || token == null)
            {
                return RedirectToAction("LogIn", "Authentication");
            }
            var validation = await _resetPasswordValidator.ValidateAsync(request);
            if(!validation.IsValid)
            {
                List<string> errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
                return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });

            }

            var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);
            if(hasUser != null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            var resetPasswordResult = await _userManager.ResetPasswordAsync(hasUser!, token.ToString()!,request.Password);
            if(resetPasswordResult.Succeeded)
            {
                return RedirectToAction("LogIn", "Authentication");
            } 
            else
            {
                List<string> errors = resetPasswordResult.Errors.Select(x => x.Description).ToList();
                return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
            }
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
