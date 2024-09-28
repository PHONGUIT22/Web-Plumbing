using AutoMapper;
using CoreLayer.Enumerators;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Helpers.Generic.Image;
using ServiceLayer.Helpers.Identity.ModelStateHelper;

namespace Web.Plumbing.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class AuthenticationUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IValidator<UserEditVM> _userEditValidator;
        private readonly IImageHelper _imageHelper;
        public AuthenticationUserController(UserManager<AppUser> userManager, IMapper mapper, IValidator<UserEditVM> userEditValidator, SignInManager<AppUser> signInManager, IImageHelper imageHelper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userEditValidator = userEditValidator;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
        }
        [HttpGet]
        public async Task<ActionResult> UserEdit()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!)!;
            var userEditVm=_mapper.Map<UserEditVM>(user);
            return View(userEditVm);
        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditVM request)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);

            // Validate request model
            var validation = await _userEditValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }

            // Check the current password
            var passwordCheck = await _userManager.CheckPasswordAsync(user!, request.Password);
            if (!passwordCheck)
            {
                ViewBag.Result = "Failed Password";
                ModelState.AddModelErrorList(new List<string> { "Wrong Password!" });
                return View();
            }

            // Handle password change if a new password is provided
            if (request.NewPassword != null)
            {
                var passwordChange = await _userManager.ChangePasswordAsync(user!, request.Password, request.NewPassword);
                if (!passwordChange.Succeeded)
                {
                    ViewBag.Result = "NewPasswordFailure";
                    ModelState.AddModelErrorList(passwordChange.Errors);
                    return View();
                }
            }

            // Keep track of old file name and type
            var oldFilename = user!.FileName;
            var oldFiletype = user!.FileType;

            // Handle profile picture upload
            if (request.Photo != null)
            {
                var image = await _imageHelper.ImageUpload(request.Photo, ImageType.identity, null);
                if (image.Error != null)
                {
                    ModelState.AddModelError("Photo", "Image upload failed.");
                    return View();
                }

                // Update file name and type in request model
                request.FileName = image.Filename;
                request.FileType = request.Photo.ContentType;
            }
            else
            {
                // Retain old file name and type if no new image is uploaded
                request.FileName = oldFilename;
                request.FileType = oldFiletype;
            }

            // Map updated fields back to the user entity
            var mappedUser = _mapper.Map(request, user);
            var userUpdate = await _userManager.UpdateAsync(mappedUser);

            if (userUpdate.Succeeded)
            {
                // If photo is updated, delete the old one
                if (request.Photo != null && oldFilename != null)
                {
                    _imageHelper.DeleteImage(oldFilename);
                }

                // Update security stamp and re-sign in the user
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Dashboard", new { Area = "User" });
            }

            // If user update failed and new image was uploaded, delete the new image
            if (request.FileName != null)
            {
                _imageHelper.DeleteImage(request.FileName);
            }

            if (request.NewPassword != null)
            {
                // No need to revert the password change
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, false);
            }

            ViewBag.Username = user.UserName;
            return View();
        }
    }
}
