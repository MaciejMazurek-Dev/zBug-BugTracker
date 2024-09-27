using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using BugTracker.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Persistence.Repositories
{
    public class IssueRepository : GenericRepository<Issue>, IIssueRepository
    {
        public IssueRepository(BTDatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
