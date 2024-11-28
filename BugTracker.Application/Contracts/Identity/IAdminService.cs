using BugTracker.Application.Models.Identity;

namespace BugTracker.Application.Contracts.Identity
{
    public interface IAdminService
    {
        Task<bool> AddRole(string userId, string roleName);
        
    }
}
