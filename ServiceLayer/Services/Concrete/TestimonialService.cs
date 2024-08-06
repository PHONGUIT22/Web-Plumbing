using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Testimonial;
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
    public class TestimonialService:ITestimonialService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Testimonial> _repository;

        public TestimonialService(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<Testimonial>();
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
            var testimonial = _mapper.Map<Testimonial>(request);
            await _repository.AddEntityAsync(testimonial);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteTestimonialAsync(int id)
        {
            var testimonial = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(testimonial);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<TestimonialUpdateVM> GetTestimonialById(int id)
        {
            var testimonial = await _repository.Where(x => x.Id == id).ProjectTo<TestimonialUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return testimonial;
        }
        public async Task UpdateTestimonialAsync(TestimonialUpdateVM request)
        {
            var testimonial = _mapper.Map<Testimonial>(request);
            _repository.UpdateEntity(testimonial);
            await _unitOfWorks.CommitAsync();
        }
    }
}
