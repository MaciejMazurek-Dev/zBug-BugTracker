using BugTracker.BlazorUI.Models.Role;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IRoleService
    {
        Task<List<RoleVM>> GetRoles(string userId);
        Task<List<RoleVM>> GetAllRoles();
    }
}
