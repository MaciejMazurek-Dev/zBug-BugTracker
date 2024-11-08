using BugTracker.BlazorUI.Models.IssueStatus;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssueStatusService
    {
        Task<List<IssueStatusVM>> GetAllIssueStatuses();
        Task<IssueStatusVM> GetIssueStatusById(int id);
        Task CreateIssueStatus(IssueStatusVM issueStatus);
        Task UpdateIssueStatus(int id, IssueStatusVM issueStatus);
        Task DeleteIssueStatus(int id);
    }
}
