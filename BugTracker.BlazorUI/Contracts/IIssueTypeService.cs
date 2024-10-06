using BugTracker.BlazorUI.Models.IssueTypes;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssueTypeService
    {
        Task<List<IssueTypeVM>> GetAllIssueTypes();
        Task<IssueTypeVM> GetIssueTypeById(int id);
        Task<Response<Guid>> CreateIssueType(IssueTypeVM issueType);
        Task<Response<Guid>> UpdateIssueType(int id, IssueTypeVM issueType);
        Task<Response<Guid>> DeleteIssueType(int id);
    }
}
