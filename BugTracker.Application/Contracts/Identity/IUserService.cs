using BugTracker.Application.Models.Identity;

namespace BugTracker.Application.Contracts.Identity
{
    public interface IUserService
    {
        public string GetCurrentUserId();
        public Task<UserModel> GetUser(string id);
        public Task<List<UserModel>> GetUsers();
    }
}
