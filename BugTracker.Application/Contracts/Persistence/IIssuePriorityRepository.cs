using BugTracker.Domain;

namespace BugTracker.Application.Contracts.Persistence
{
    public interface IIssuePriorityRepository : IGenericRepository<IssuePriority>
    {
        Task<bool> IsPriorityNameUnique(string name);
    }
}
