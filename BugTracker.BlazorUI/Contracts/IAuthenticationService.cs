using BugTracker.BlazorUI.Models.Authentication;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Contracts
{
    public interface IAuthenticationService
    {
        Task<Response<LoginResponse>> LoginAsync(LoginVM loginVM);
        Task<Response<RegisterResponse>> RegisterAsync(RegisterVM registerVM);
        Task Logout();
    }
}
