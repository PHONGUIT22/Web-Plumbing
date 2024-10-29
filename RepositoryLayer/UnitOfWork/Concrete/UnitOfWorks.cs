using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.Repositories.Concrete;
using RepositoryLayer.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.UnitOfWork.Concrete
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly AppDbContext _context;

        public UnitOfWorks(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
           
                await _context.SaveChangesAsync();
                
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        IGenericRepositories<T> IUnitOfWorks.GetGenericRepository<T>()
        {
            return new GenericRepositories<T>(_context);
        }
    }
}
