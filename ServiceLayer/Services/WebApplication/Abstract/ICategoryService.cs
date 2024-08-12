using EntityLayer.WebApplication.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryListVM>> GetAllListAsync();
        Task AddCategoryAsync(CategoryAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<CategoryUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(CategoryUpdateVM request);
    }
}
