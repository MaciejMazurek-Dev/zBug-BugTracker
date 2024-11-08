using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssuePriorityService
    {
        Task<List<IssuePriorityVM>> GetAllIssuePriorities();
        Task<IssuePriorityVM> GetIssuePriorityById(int id);
        Task CreateIssuePriority(IssuePriorityVM issuePriority);
        Task UpdateIssuePriority(int id, IssuePriorityVM issuePriority);
        Task DeleteIssuePriority(int id);
    }
}
