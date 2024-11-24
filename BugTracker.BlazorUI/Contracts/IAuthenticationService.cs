using BugTracker.BlazorUI.Models.Authentication;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(LoginVM loginVM);

        Task<bool> RegisterAsync(RegisterVM registerVM);

        Task Logout();
    }
}
