namespace BugTracker.BlazorUI.Contracts
{
    public interface ITokenRefreshService
    {
        Task<bool> RefreshToken();
    }
}
