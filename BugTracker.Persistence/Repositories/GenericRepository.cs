using BugTracker.Application.Contracts.Persistence;
using BugTracker.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Persistence.Repositories
{
    public class GenericRepository<T>  : IGenericRepository<T> where T : class
    {
        protected readonly BTDatabaseContext _dbContext;

        public GenericRepository(BTDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
