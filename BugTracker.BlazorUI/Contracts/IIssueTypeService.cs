using BugTracker.BlazorUI.Models.IssueTypes;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssueTypeService
    {
        Task<List<IssueTypeVM>> GetAllIssueTypes();
        Task<IssueTypeVM> GetIssueTypeById(int id);
        Task CreateIssueType(IssueTypeVM issueType);
        Task UpdateIssueType(int id, IssueTypeVM issueType);
        Task DeleteIssueType(int id);
    }
}
