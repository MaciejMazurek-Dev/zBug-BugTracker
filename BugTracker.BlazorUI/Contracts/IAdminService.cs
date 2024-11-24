using BugTracker.BlazorUI.Models.Admin;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IAdminService
    {
        public Task<List<UserVM>> GetUsers();
    }
}
