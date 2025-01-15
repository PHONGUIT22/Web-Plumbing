using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace Web.Plumbing.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private readonly ITeamService _teamService;
        public TeamViewComponent(ITeamService teamService)
        {
            _teamService = teamService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var teamList = await _teamService.GetTeamListForUIAsync();
            return View(teamList);
        }
    }
}
