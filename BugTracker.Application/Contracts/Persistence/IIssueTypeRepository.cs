using BugTracker.Domain;

namespace BugTracker.Application.Contracts.Persistence
{
    public interface IIssueTypeRepository : IGenericRepository<IssueType>
    {
        Task<bool> IsTypeNameUnique(string name);
    }
}
