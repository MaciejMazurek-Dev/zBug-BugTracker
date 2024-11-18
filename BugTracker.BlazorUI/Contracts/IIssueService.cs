using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssueService
    {
        Task<List<IssueVM>> GetAllIssues();
        Task<IssueDetailsVM> GetIssueById(int id);
        Task CreateIssue(CreateIssueVM issue);
        Task UpdateIssue(int id, IssueVM issue);
        Task DeleteIssue(int id);
    }
}
