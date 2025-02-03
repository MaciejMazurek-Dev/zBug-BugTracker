using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using BugTracker.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BugTracker.Persistence.Repositories
{
    public class IssueRepository : GenericRepository<Issue>, IIssueRepository
    {
        public IssueRepository(BTDatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Issue>> GetAllIssues()
        {
            var issues = await _dbContext.Issues
                .Include(q => q.IssueType)
                .Include(q => q.IssueStatus)
                .Include(q => q.IssuePriority)
                .ToListAsync();
            return issues;
        }

        public async Task<Issue> GetIssueById(int id)
        {
            var issue = await _dbContext.Issues
                .Include(q => q.IssueType)
                .Include(q => q.IssueStatus)
                .Include(q => q.IssuePriority)
                .FirstOrDefaultAsync(q => q.Id == id);
            return issue;
        }

        public async Task<List<Issue>> GetIssuesByFilter(int? type, int? priority, int? status)
        {
            var issues = await _dbContext.Issues
                .Include(q => q.IssueStatus)
                .Include(q => q.IssueType)
                .Include(q => q.IssuePriority)
                .Where(q => !type.HasValue || q.IssueTypeId == type)
                .Where(q => !status.HasValue || q.IssueStatusId == status)
                .Where(q => !priority.HasValue || q.IssuePriorityId == priority)
                .ToListAsync();

            return issues;
        }

        public async Task<List<Issue>> GetIssuesByUser(string userId)
        {
            var issues = await _dbContext.Issues
                .Include(q => q.IssueType)
                .Include(q => q.IssueStatus)
                .Include(q => q.IssuePriority)
                .Where(q => q.ReporterId == userId)
                .ToListAsync();
            
            return issues;
        }

    }
}
