using CoreLayer.BaseEntities;
using RepositoryLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWork.Abstract
{
    public interface IUnitOfWorks
    {
        void Commit();
        Task CommitAsync();
        IGenericRepositories<T> GetGenericRepository<T>() where T : class, IBaseEntity,new();
        ValueTask DisposeAsync();
    }
}
