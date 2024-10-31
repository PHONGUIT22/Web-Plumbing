using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Plumbing.Areas.User.Controllers
{
    [Authorize(Roles = "MemBer,SuperAdmin")]
    [Area("User")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
