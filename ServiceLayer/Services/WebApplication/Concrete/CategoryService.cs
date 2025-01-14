using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Category;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Category> _repository;

        public CategoryService(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<Category>();
        }
        public async Task<List<CategoryListVM>> GetAllListAsync()
        {
            //var CategoryList = await _unitOfWorks.GetGenericRepository<Category>().GetAllEntityList().ToListAsync();
            //var CategoryListVM = _mapper.Map<List<CategoryListVM>>(CategoryList);

            var categoryListVM = await _repository.GetAllEntityList().ProjectTo<CategoryListVM>
            (_mapper.ConfigurationProvider).ToListAsync();
            return categoryListVM;
        }

        public async Task AddCategoryAsync(CategoryAddVM request)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.AddEntityAsync(category);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var Category = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(Category);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<CategoryUpdateVM> GetCategoryById(int id)
        {
            var category = await _repository.Where(x => x.Id == id).ProjectTo<CategoryUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return category;
        }
        public async Task UpdateCategoryAsync(CategoryUpdateVM request)
        {
            var category = _mapper.Map<Category>(request);
            _repository.UpdateEntity(category);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<List<CategoryListForUI>> GetAllListForUIAsync()
        {
            var categoryListForUI = await _repository.GetAllEntityList().ProjectTo<CategoryListForUI>
            (_mapper.ConfigurationProvider).ToListAsync();
            return categoryListForUI;
        }
    }
}
