/*using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Plumbing.Areas.User.Components
{
    [Authorize]
    [Area("User")]
    public class LayoutViewComponent : ViewComponent
    {

        private readonly UserManager<AppUser> _userManager;
        public LayoutViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Username)
        {
            
            if (Username == null)
            {
                Username = User.Identity!.Name!;
            }
            var user = await _userManager.FindByIdAsync(Username);
            if (user!.FileName == null)
            {
                return View(new UserPictureVM { FileName = "Default" });
            }
            return View(new UserPictureVM { FileName = user.FileName });
        }
    }

} */


using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Plumbing.Areas.User.Components
{
    [Authorize]
    [Area("User")]
    public class LayoutViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public LayoutViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Username)
        {
            // Kiểm tra nếu Username không được cung cấp từ trước
            if (string.IsNullOrEmpty(Username))
            {
                // Kiểm tra xem User.Identity có null không
                if (User.Identity != null && !string.IsNullOrEmpty(User.Identity.Name))
                {
                    Username = User.Identity.Name;  // Lấy Username từ User.Identity
                }
                else
                {
                    // Nếu không thể lấy Username, trả về ảnh mặc định
                    return View(new UserPictureVM { FileName = "Default" });
                }
            }

            // Tìm user dựa trên Username
            var user = await _userManager.FindByNameAsync(Username); // Sử dụng FindByNameAsync thay vì FindByIdAsync

            // Kiểm tra nếu user không tồn tại hoặc FileName của user là null
            if (user == null || string.IsNullOrEmpty(user.FileName))
            {
                return View(new UserPictureVM { FileName = "Default" });
            }

            // Trả về ảnh người dùng nếu có
            return View(new UserPictureVM { FileName = user.FileName });
        }
    }
}
