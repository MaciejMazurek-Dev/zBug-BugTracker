using BugTracker.Application.Contracts.Persistence;
using BugTracker.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Persistence.Repositories
{
    public class GenericRepository : IGenericRepository<T>
    {
        protected readonly BTDatabaseContext _dbContext;

        public GenericRepository(BTDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        

        
    }
}
