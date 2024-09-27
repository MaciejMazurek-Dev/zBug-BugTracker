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
    public class IssueStatusRepository : GenericRepository<IssueStatus>, IIssueStatusRepository
    {
        public IssueStatusRepository(BTDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsStatusNameUnique(string name)
        {
            return await _dbContext.IssueStatuses.AnyAsync(q => q.Name == name);
        }
    }
}
