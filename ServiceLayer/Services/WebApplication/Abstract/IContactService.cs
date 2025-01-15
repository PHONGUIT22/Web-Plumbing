using EntityLayer.WebApplication.ViewModels.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Abstract
{
    public interface IContactService
    {
        Task<List<ContactListVM>> GetAllListAsync();
        Task AddContactAsync(ContactAddVM request);
        Task DeleteContactAsync(int id);
        Task<ContactUpdateVM> GetContactById(int id);
        Task UpdateContactAsync(ContactUpdateVM request);
        Task<List<ContactListForUI>> GetAllListForUIAsync();
    }
}
