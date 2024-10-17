using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreLayer.Enumerators;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Testimonial;
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
    public class TestimonialService : ITestimonialService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Testimonial> _repository;
        private readonly IImageHelper _imageHelper;

        public TestimonialService(IUnitOfWorks unitOfWorks, IMapper mapper, IImageHelper imageHelper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<Testimonial>();
            _imageHelper = imageHelper;
        }
        public async Task<List<TestimonialListVM>> GetAllListAsync()
        {
            //var TestimonialList = await _unitOfWorks.GetGenericRepository<Testimonial>().GetAllEntityList().ToListAsync();
            //var TestimonialListVM = _mapper.Map<List<TestimonialListVM>>(TestimonialList);

            var testimonialListVM = await _repository.GetAllEntityList().ProjectTo<TestimonialListVM>
            (_mapper.ConfigurationProvider).ToListAsync();
            return testimonialListVM;
        }

        public async Task AddTestimonialAsync(TestimonialAddVM request)
        {
            var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.testimonal, null);
            if (imageResult.Error != null)
            {
                return;
            }
            request.FileName = imageResult.Filename!;
            request.FileType = imageResult.FileType!;
            var testimonial = _mapper.Map<Testimonial>(request);
            await _repository.AddEntityAsync(testimonial);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            var testimonial = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(testimonial);
            await _unitOfWorks.CommitAsync();
            _imageHelper.DeleteImage(testimonial.FileName);
        }

        public async Task<TestimonialUpdateVM> GetTestimonialById(int id)
        {
            var testimonial = await _repository.Where(x => x.Id == id).ProjectTo<TestimonialUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return testimonial;
        }
        public async Task UpdateTestimonialAsync(TestimonialUpdateVM request)
        {
            var oldTestimonial = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();

            if (request.Photo != null)
            {
                var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.testimonal, null);
                if (imageResult.Error != null)
                {
                    return;
                }
                request.FileName = imageResult.Filename!;
                request.FileType = imageResult.FileType!;
            }
            var testimonial = _mapper.Map<Testimonial>(request);
            _repository.UpdateEntity(testimonial);
            await _unitOfWorks.CommitAsync();
            if (request.Photo != null)
            {
                _imageHelper.DeleteImage(oldTestimonial.FileName);
            }
        }
    }
}
