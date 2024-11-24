using BugTracker.Application.Models.Identity;

namespace BugTracker.Application.Contracts.Identity
{
    public interface IAdminService
    {
        public Task<List<UserModel>> GetUsers();
    }
}
