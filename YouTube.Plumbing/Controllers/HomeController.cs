using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace YouTube.Plumbing.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
