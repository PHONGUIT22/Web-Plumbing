using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Team;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Team> _repository;

        public TeamService(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<Team>();
        }
        public async Task<List<TeamListVM>> GetAllListAsync()
        {
            //var TeamList = await _unitOfWorks.GetGenericRepository<Team>().GetAllEntityList().ToListAsync();
            //var TeamListVM = _mapper.Map<List<TeamListVM>>(TeamList);

            var teamListVM = await _repository.GetAllEntityList().ProjectTo<TeamListVM>
            (_mapper.ConfigurationProvider).ToListAsync();
            return teamListVM;
        }

        public async Task AddTeamAsync(TeamAddVM request)
        {
            var team = _mapper.Map<Team>(request);
            await _repository.AddEntityAsync(team);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(team);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<TeamUpdateVM> GetTeamById(int id)
        {
            var team = await _repository.Where(x => x.Id == id).ProjectTo<TeamUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return team;
        }
        public async Task UpdateTeamAsync(TeamUpdateVM request)
        {
            var team = _mapper.Map<Team>(request);
            _repository.UpdateEntity(team);
            await _unitOfWorks.CommitAsync();
        }
    }
}
