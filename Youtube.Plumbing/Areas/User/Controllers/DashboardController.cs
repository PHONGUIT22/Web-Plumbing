using Microsoft.AspNetCore.Mvc;

namespace Web.Plumbing.Areas.User.Controllers
{
    [Area("User")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
