using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IIssuePriorityService
    {
        Task<List<IssuePriorityVM>> GetAllIssuePriorities();
        Task<IssuePriorityVM> GetIssuePriorityById(int id);
        Task<Response<Guid>> CreateIssuePriority(IssuePriorityVM issuePriority);
        Task<Response<Guid>> UpdateIssuePriority(int id, IssuePriorityVM issuePriority);
        Task<Response<Guid>> DeleteIssuePriority(int id);
    }
}
