using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BugTracker.BlazorUI.Providers
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public const string ACCESS_TOKEN_NAME = "AccessToken";
        public const string REFRESH_TOKEN_NAME = "RefreshToken";
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task LogIn(string accessToken, string refreshToken)
        {
            await _localStorage.SetItemAsync(ACCESS_TOKEN_NAME, accessToken);
            await _localStorage.SetItemAsync(REFRESH_TOKEN_NAME, refreshToken);

            List<Claim> claims = await GetClaims();
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            Task<AuthenticationState> authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LogOut()
        {
            await _localStorage.RemoveItemAsync(ACCESS_TOKEN_NAME);
            await _localStorage.RemoveItemAsync(REFRESH_TOKEN_NAME);
            ClaimsPrincipal emptyUser = new ClaimsPrincipal(new ClaimsIdentity());
            Task<AuthenticationState> authState = Task.FromResult(new AuthenticationState(emptyUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity());
            string? localToken = await _localStorage.GetItemAsync<string>(ACCESS_TOKEN_NAME);

            if (localToken == null)
            {
                return new AuthenticationState(user);
            }
            JwtSecurityToken token = _jwtSecurityTokenHandler.ReadJwtToken(localToken);
            if (token.ValidTo < DateTime.UtcNow)
            {
                return new AuthenticationState(user);
            }
            var claims = await GetClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            return new AuthenticationState(user);
        }

        private async Task<List<Claim>> GetClaims()
        {
            string localToken = await _localStorage.GetItemAsync<string>(ACCESS_TOKEN_NAME);
            JwtSecurityToken jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(localToken);

            List<Claim> claims = jwtToken.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, jwtToken.Subject));
            return claims;
        }

        public async Task<string?> GetRefreshToken()
        {
            return await _localStorage.GetItemAsync<string>(REFRESH_TOKEN_NAME);
        }

        public async Task DeleteRefreshToken()
        {
            await _localStorage.RemoveItemAsync(REFRESH_TOKEN_NAME);
            return;
        }

        public async Task<string?> GetAccessToken()
        {
            return await _localStorage.GetItemAsync<string>(ACCESS_TOKEN_NAME);
        }

        public async Task<bool> IsAccessTokenStillValid()
        {
            var token = await GetAccessToken();
            if(token != null)
            {
                JwtSecurityToken accessToken = _jwtSecurityTokenHandler.ReadJwtToken(token);
                var currentTime = DateTime.UtcNow.AddMinutes(1);
                if (accessToken.ValidTo > currentTime)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
