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
    public class IssueTypeRepository : GenericRepository<IssueType>, IIssueTypeRepository
    {
        public IssueTypeRepository(BTDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsTypeNameUnique(string name)
        {
            return await _dbContext.IssueTypes.AnyAsync(q => q.Name == name);
        }
    }
}
