using EntityLayer.WebApplication.ViewModels.AboutVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IAboutService
    {
        Task<List<AboutListVM>> GetAllListAsync();
        Task AddAboutAsync(AboutAddVM request);
        Task DeleteAboutAsync(int id);
        Task<AboutUpdateVM> GetAboutById(int id);
        Task UpdateAboutAsync(AboutUpdateVM request);
    }
}
