using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Enumerators;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
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
    public class AboutService : IAboutService
    {

        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<About> _repository;
        private readonly IImageHelper _imageHelper;

        public AboutService(IUnitOfWorks unitOfWorks, IMapper mapper, IImageHelper imageHelper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<About>();
            _imageHelper = imageHelper;
        }
        public async Task<List<AboutListVM>> GetAllListAsync()
        {
            //var aboutList = await _unitOfWorks.GetGenericRepository<About>().GetAllEntityList().ToListAsync();
            //var aboutListVM = _mapper.Map<List<AboutListVM>>(aboutList);

            var aboutListVM = await _repository.GetAllEntityList().ProjectTo<AboutListVM>
            (_mapper.ConfigurationProvider).ToListAsync();
            return aboutListVM;
        }

        public async Task AddAboutAsync(AboutAddVM request)
        {
            
           var imageResult = await _imageHelper.ImageUpload(request.Photo,ImageType.about,null);
           if(imageResult.Error != null)
           {
                return;
           }
            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;
           var about = _mapper.Map<About>(request);
           await _repository.AddEntityAsync(about);
           await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteAboutAsync(int id)
        {
            var about = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(about);
            await _unitOfWorks.CommitAsync();
            _imageHelper.DeleteImage(about.FileName);    
        }

        public async Task<AboutUpdateVM> GetAboutById(int id)
        {
            var about = await _repository.Where(x => x.Id == id).ProjectTo<AboutUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return about;
        }
        public async Task UpdateAboutAsync(AboutUpdateVM request)
        {
            var oldAbout = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();

            if (request.Photo != null)
            {
                var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.about, null);
                if (imageResult.Error != null)
                {
                    return;
                }
                request.FileName = imageResult.Filename!;
                request.FileType = imageResult.FileType!;
            }
            var about = _mapper.Map<About>(request);
            _repository.UpdateEntity(about);
            await _unitOfWorks.CommitAsync();
            if(request.Photo != null)
            {
                _imageHelper.DeleteImage(oldAbout.FileName);
            }
        }
    }
}
