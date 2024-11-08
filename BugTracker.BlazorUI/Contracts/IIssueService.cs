using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssueService
    {
        Task<List<IssueVM>> GetAllIssues();
        Task<IssueVM> GetIssueById(int id);
        Task CreateIssue(IssueVM issue);
        Task UpdateIssue(int id, IssueVM issue);
        Task DeleteIssue(int id);
    }
}
