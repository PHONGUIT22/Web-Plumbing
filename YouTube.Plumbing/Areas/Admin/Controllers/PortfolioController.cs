using EntityLayer.WebApplication.ViewModels.Portfolio;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> GetPortfolioList()
        {
            var portfolioList = await _portfolioService.GetAllListAsync();
            return View(portfolioList);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioAddVM request)
        {
            await _portfolioService.AddPortfolioAsync(request);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePortfolio(int id)
        {
            var Portfolio = await _portfolioService.GetPortfolioById(id);
            return View(Portfolio);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(PortfolioUpdateVM request)
        {
            await _portfolioService.UpdatePortfolioAsync(request);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeletePortfolio(int id)
        {   
            await _portfolioService.DeletePortfolioAsync(id);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
        }
    }
}
