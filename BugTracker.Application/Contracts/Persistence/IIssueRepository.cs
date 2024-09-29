using BugTracker.Domain;

namespace BugTracker.Application.Contracts.Persistence
{
    public interface IIssueRepository : IGenericRepository<Issue>
    {
        Task<Issue> GetIssueById(int id);
        Task<List<Issue>> GetAllIssues();
        Task<List<Issue>> GetIssuesByUser(string userId);
    }
}
