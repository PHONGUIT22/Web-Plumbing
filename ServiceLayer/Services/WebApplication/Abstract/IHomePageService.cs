using EntityLayer.WebApplication.ViewModels.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IHomePageService
    {
        Task<List<HomePageListVM>> GetAllListAsync();
        Task AddHomePageAsync(HomePageAddVM request);
        Task DeleteHomePageAsync(int id);
        Task<HomePageUpdateVM> GetHomePageById(int id);
        Task UpdateHomePageAsync(HomePageUpdateVM request);
        Task<List<HomePageVMForUI>> GetAllListForUIAsync();
    }
}
