using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Security.Claims;

namespace Web.Plumbing.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserver")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toasty;
        public AdminController(UserManager<AppUser> userManager, IMapper mapper, IToastNotification toasty)
        {
            _userManager = userManager;
            _mapper = mapper;
            _toasty = toasty;
        }

        public async Task<IActionResult> GetUserList()
        {
            var userList = await _userManager.Users.ToListAsync();
            var userListVM = _mapper.Map<List<UserVM>>(userList);
            for(int i = 0; i < userList.Count; i++)
            {
                var userRoles = await _userManager.GetRolesAsync(userList[i]);
                userListVM[i].UserRoles = userRoles;
                var userClaims = await _userManager.GetClaimsAsync(userList[i]);
                userListVM[i].UserClaims = userClaims;

            }
            return View(userListVM);
        }
        public async Task<IActionResult> ExtendClaim(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var claims = await _userManager.GetClaimsAsync(user!);
            var existingClaim = claims.FirstOrDefault(x => x.Type.Contains("Observer"));
            var newExtendedClaim = new Claim("AdminObserverExpireDate", DateTime.Now.AddDays(5).ToString());
            var renewClaim = await _userManager.ReplaceClaimAsync(user!,existingClaim!,newExtendedClaim);
            return RedirectToAction("GetUserList", "Admin", new { Area = "Admin" });
        }
    }
}
