using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Plumbing.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminObserver")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AdminController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
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
    }
}
