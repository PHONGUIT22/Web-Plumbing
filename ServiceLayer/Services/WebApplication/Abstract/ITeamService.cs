using EntityLayer.WebApplication.ViewModels.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface ITeamService
    {
        Task<List<TeamListVM>> GetAllListAsync();
        Task AddTeamAsync(TeamAddVM request);
        Task DeleteTeamAsync(int id);
        Task<TeamUpdateVM> GetTeamById(int id);
        Task UpdateTeamAsync(TeamUpdateVM request);
    }
}
