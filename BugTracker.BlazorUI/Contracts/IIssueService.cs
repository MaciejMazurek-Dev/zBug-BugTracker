using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssueService
    {
        Task<List<IssueVM>> GetAllIssues();
        Task<IssueVM> GetIssueById(int id);
        Task<Response<Guid>> CreateIssue(IssueVM issue);
        Task<Response<Guid>> UpdateIssue(int id, IssueVM issue);
        Task<Response<Guid>> DeleteIssue(int id);
    }
}
