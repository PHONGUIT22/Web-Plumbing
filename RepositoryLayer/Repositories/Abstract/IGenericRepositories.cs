using CoreLayer.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Abstract
{
    public interface IGenericRepositories<T> where T : class, IBaseEntity, new()
    {
        Task AddEntityAsync(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        IQueryable<T> GetAllEntityList();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<T> GetEntityByIdAsync(int id);
    }
}
