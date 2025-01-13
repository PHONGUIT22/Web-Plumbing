using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePage;
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
    public class HomePageService : IHomePageService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<HomePage> _repository;

        public HomePageService(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<HomePage>();
        }
        public async Task<List<HomePageListVM>> GetAllListAsync()
        {
            //var HomePageList = await _unitOfWorks.GetGenericRepository<HomePage>().GetAllEntityList().ToListAsync();
            //var HomePageListVM = _mapper.Map<List<HomePageListVM>>(HomePageList);

            var homePageListVM = await _repository.GetAllEntityList().ProjectTo<HomePageListVM>
            (_mapper.ConfigurationProvider).ToListAsync();
            return homePageListVM;
        }

        public async Task AddHomePageAsync(HomePageAddVM request)
        {
            var homePage = _mapper.Map<HomePage>(request);
            await _repository.AddEntityAsync(homePage);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteHomePageAsync(int id)
        {
            var homePage = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(homePage);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<HomePageUpdateVM> GetHomePageById(int id)
        {
            var homePage = await _repository.Where(x => x.Id == id).ProjectTo<HomePageUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return homePage;
        }
        public async Task UpdateHomePageAsync(HomePageUpdateVM request)
        {
            var homePage = _mapper.Map<HomePage>(request);
            _repository.UpdateEntity(homePage);
            await _unitOfWorks.CommitAsync();
        }
        //UI service methods
        public async Task<List<HomePageVMForUI>> GetAllListForUIAsync()
        {
            var homePageListVMForUI = await _repository.GetAllEntityList().ProjectTo<HomePageVMForUI>
            (_mapper.ConfigurationProvider).ToListAsync();
            return homePageListVMForUI;
        }
    }
}
