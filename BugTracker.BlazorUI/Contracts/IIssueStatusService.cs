using BugTracker.BlazorUI.Models.IssueStatus;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssueStatusService
    {
        Task<List<IssueStatusVM>> GetAllIssueStatuses();
        Task<IssueStatusVM> GetIssueStatusById(int id);
        Task<Response<Guid>> CreateIssueStatus(IssueStatusVM issueStatus);
        Task<Response<Guid>> UpdateIssueStatus(int id, IssueStatusVM issueStatus);
        Task<Response<Guid>> DeleteIssueStatus(int id);
    }
}
