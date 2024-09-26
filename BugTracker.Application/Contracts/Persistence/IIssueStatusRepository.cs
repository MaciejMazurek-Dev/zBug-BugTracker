using BugTracker.Domain;

namespace BugTracker.Application.Contracts.Persistence
{
    public interface IIssueStatusRepository : IGenericRepository<IssueStatus>
    {
        Task<bool> IsStatusNameUnique(string name);
    }
}
