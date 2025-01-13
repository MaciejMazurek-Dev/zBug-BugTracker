using BugTracker.Application.Models.Identity;

namespace BugTracker.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<RegisterResponse> Register(RegisterRequest registrationRequest);
        Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest);
    }
}
