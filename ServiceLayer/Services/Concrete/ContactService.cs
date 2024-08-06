using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Contact;
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
    public class ContactService:IContactService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Contact> _repository;

        public ContactService(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _repository = _unitOfWorks.GetGenericRepository<Contact>();
        }
        public async Task<List<ContactListVM>> GetAllListAsync()
        {
            //var ContactList = await _unitOfWorks.GetGenericRepository<Contact>().GetAllEntityList().ToListAsync();
            //var ContactListVM = _mapper.Map<List<ContactListVM>>(ContactList);

            var contactListVM = await _repository.GetAllEntityList().ProjectTo<ContactListVM>
            (_mapper.ConfigurationProvider).ToListAsync();
            return contactListVM;
        }

        public async Task AddContactAsync(ContactAddVM request)
        {
            var contact = _mapper.Map<Contact>(request);
            await _repository.AddEntityAsync(contact);
            await _unitOfWorks.CommitAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(contact);
            await _unitOfWorks.CommitAsync();
        }

        public async Task<ContactUpdateVM> GetContactById(int id)
        {
            var contact = await _repository.Where(x => x.Id == id).ProjectTo<ContactUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return contact;
        }
        public async Task UpdateContactAsync(ContactUpdateVM request)
        {
            var contact = _mapper.Map<Contact>(request);
            _repository.UpdateEntity(contact);
            await _unitOfWorks.CommitAsync();
        }
    }
}
