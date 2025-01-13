using BugTracker.BlazorUI.Models.User;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IUserService
    {
        public Task<List<UserVM>> GetUsers();
        public Task<UserVM> GetUser(string id);
    }
}
