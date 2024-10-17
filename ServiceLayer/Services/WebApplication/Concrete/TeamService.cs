using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Enumerators;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Team;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Helpers.Generic.Image;
using ServiceLayer.Services.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Team> _repository;
        private readonly IImageHelper _imageHelper;
        public TeamService(IUnitOfWorks unitOfWorks, IMapper mapper, IImageHelper imageHelper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<Team>();
            _imageHelper = imageHelper; 
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
            var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.team, null);
            if (imageResult.Error != null)
            {
                return;
            }
            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;
            var team = _mapper.Map<Team>(request);
            await _repository.AddEntityAsync(team);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteTeamAsync(int id)
        {
            var team = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(team);
            await _unitOfWorks.CommitAsync();
            _imageHelper.DeleteImage(team.FileName);
        }

        public async Task<TeamUpdateVM> GetTeamById(int id)
        {
            var team = await _repository.Where(x => x.Id == id).ProjectTo<TeamUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return team;
        }
        public async Task UpdateTeamAsync(TeamUpdateVM request)
        {
            var oldTeam = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();

            if (request.Photo != null)
            {
                var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.team, null);
                if (imageResult.Error != null)
                {
                    return;
                }
                request.FileName = imageResult.Filename!;
                request.FileType = imageResult.FileType!;
            }
            var team = _mapper.Map<Team>(request);
            _repository.UpdateEntity(team);
            await _unitOfWorks.CommitAsync();
            if (request.Photo != null)
            {
                _imageHelper.DeleteImage(oldTeam.FileName);
            }
        }
    }
}
