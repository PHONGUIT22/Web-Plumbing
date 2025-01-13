using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace Web.Plumbing.Components
{
    public class PortfolioViewComponent : ViewComponent
    {
        private readonly IPortfolioService _portfolioService;
        public PortfolioViewComponent(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var porfolioList = await _portfolioService.GetAllListForUIAsync();
            return View(porfolioList);
        }
    }
}
