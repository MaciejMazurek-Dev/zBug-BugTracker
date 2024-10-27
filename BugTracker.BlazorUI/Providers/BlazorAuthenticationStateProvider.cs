using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BugTracker.BlazorUI.Providers
{
    public class BlazorAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public BlazorAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task LogIn()
        {
            List<Claim> claims = await GetClaims();
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            Task<AuthenticationState> authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public async Task LogOut()
        {
            await _localStorage.RemoveItemAsync("token");
            ClaimsPrincipal emptyUser = new ClaimsPrincipal(new ClaimsIdentity());
            Task<AuthenticationState> authState = Task.FromResult(new AuthenticationState(emptyUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity());
            string? localToken = await _localStorage.GetItemAsync<string>("token");

            if(localToken == null)
            {
                return new AuthenticationState(user);
            }

            JwtSecurityToken token = _jwtSecurityTokenHandler.ReadJwtToken(localToken);

            if(token.ValidTo < DateTime.Now)
            {
                await _localStorage.RemoveItemAsync("token");
                return new AuthenticationState(user);
            }

            var claims = await GetClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            return new AuthenticationState(user);
        }


        private async Task<List<Claim>> GetClaims()
        {
            string localToken = await _localStorage.GetItemAsync<string>("token");
            JwtSecurityToken jwtToken = _jwtSecurityTokenHandler.ReadJwtToken(localToken);
            
            List<Claim> claims = jwtToken.Claims.ToList();
            return claims;
        }
    }
}
