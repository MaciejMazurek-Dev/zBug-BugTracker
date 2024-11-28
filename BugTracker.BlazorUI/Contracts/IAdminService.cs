namespace BugTracker.BlazorUI.Contracts
{
    public interface IAdminService
    {
        public Task AddRole(string userId, string roleName);
    }
}
