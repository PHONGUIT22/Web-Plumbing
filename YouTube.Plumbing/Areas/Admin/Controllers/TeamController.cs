using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Category;
using EntityLayer.WebApplication.ViewModels.Team;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Filters.WebApplication;
using ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IValidator<TeamAddVM> _addValidator;
        private readonly IValidator<TeamUpdateVM> _updateValidator;

        public TeamController(ITeamService teamService, IValidator<TeamAddVM> addValidator, IValidator<TeamUpdateVM> updateValidator)
        {
            _teamService = teamService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> GetTeamList()
        {
            var teamList = await _teamService.GetAllListAsync();
            return View(teamList);
        }
        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(TeamAddVM request)
        {
            var validation = await _addValidator.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _teamService.AddTeamAsync(request);
                return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
            }
            validation.AddToModelState(this.ModelState);
            return View();
        }
        [ServiceFilter(typeof(GenericNotFoundFilter<Team>))]
        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var Team = await _teamService.GetTeamById(id);
            return View(Team);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(TeamUpdateVM request)
        {
            var validation = await _updateValidator.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _teamService.UpdateTeamAsync(request);
                return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
            }
            validation.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return RedirectToAction("GetTeamList", "Team", new { Area = ("Admin") });
        }
    }
}
