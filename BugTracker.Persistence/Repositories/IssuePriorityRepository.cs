using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using BugTracker.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Persistence.Repositories
{
    public class IssuePriorityRepository : GenericRepository<IssuePriority>, IIssuePriorityRepository
    {
        public IssuePriorityRepository(BTDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsPriorityNameUnique(string name)
        {
            return await _dbContext.IssuePriorities.AnyAsync(q => q.Name == name);
        }
    }
}
