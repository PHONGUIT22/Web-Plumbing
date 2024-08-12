using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SocialMedia;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<SocialMedia> _repository;

        public SocialMediaService(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<SocialMedia>();
        }
        public async Task<List<SocialMediaListVM>> GetAllListAsync()
        {
            //var SocialMediaList = await _unitOfWorks.GetGenericRepository<SocialMedia>().GetAllEntityList().ToListAsync();
            //var SocialMediaListVM = _mapper.Map<List<SocialMediaListVM>>(SocialMediaList);

            var SocialMediaListVM = await _repository.GetAllEntityList().ProjectTo<SocialMediaListVM>
            (_mapper.ConfigurationProvider).ToListAsync();
            return SocialMediaListVM;
        }

        public async Task AddSocialMediaAsync(SocialMediaAddVM request)
        {
            var SocialMedia = _mapper.Map<SocialMedia>(request);
            await _repository.AddEntityAsync(SocialMedia);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteSocialMediaAsync(int id)
        {
            var SocialMedia = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(SocialMedia);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<SocialMediaUpdateVM> GetSocialMediaById(int id)
        {
            var SocialMedia = await _repository.Where(x => x.Id == id).ProjectTo<SocialMediaUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return SocialMedia;
        }
        public async Task UpdateSocialMediaAsync(SocialMediaUpdateVM request)
        {
            var SocialMedia = _mapper.Map<SocialMedia>(request);
            _repository.UpdateEntity(SocialMedia);
            await _unitOfWorks.CommitAsync();
        }
    }
}
