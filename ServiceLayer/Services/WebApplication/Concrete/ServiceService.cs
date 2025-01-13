using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Service;
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
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Service> _repository;

        public ServiceService(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<Service>();
        }
        public async Task<List<ServiceListVM>> GetAllListAsync()
        {
            //var ServiceList = await _unitOfWorks.GetGenericRepository<Service>().GetAllEntityList().ToListAsync();
            //var ServiceListVM = _mapper.Map<List<ServiceListVM>>(ServiceList);

            var serviceListVM = await _repository.GetAllEntityList().ProjectTo<ServiceListVM>
            (_mapper.ConfigurationProvider).ToListAsync();
            return serviceListVM;
        }

        public async Task AddServiceAsync(ServiceAddVM request)
        {
            var service = _mapper.Map<Service>(request);
            await _repository.AddEntityAsync(service);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(service);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<ServiceUpdateVM> GetServiceById(int id)
        {
            var service = await _repository.Where(x => x.Id == id).ProjectTo<ServiceUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return service;
        }
        public async Task UpdateServiceAsync(ServiceUpdateVM request)
        {
            var service = _mapper.Map<Service>(request);
            _repository.UpdateEntity(service);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<List<ServiceListForUI>> GetAllListForUIAsync()
        {
            var serviceListForUI = await _repository.GetAllEntityList().ProjectTo<ServiceListForUI>
           (_mapper.ConfigurationProvider).ToListAsync();
            return serviceListForUI;
        }
    }
}
