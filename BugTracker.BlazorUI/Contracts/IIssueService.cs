using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssueService
    {
        Task<Response<List<IssueVM>>> GetAllIssues();
        Task<Response<IssueDetailsVM>> GetIssueById(int id);
        Task<Response<bool>> CreateIssue(CreateIssueVM issue);
        Task<Response<bool>> UpdateIssue(IssueDetailsVM issue);
        Task<Response<bool>> DeleteIssue(int id);
    }
}
