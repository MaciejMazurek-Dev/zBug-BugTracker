using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Providers;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class TokenRefreshService : HttpClientService, ITokenRefreshService
    {
        private readonly CustomAuthStateProvider _authStateProvider;
        public TokenRefreshService(
            IClient client, 
            ILocalStorageService localStorage,
            CustomAuthStateProvider authStateProvider) :
            base(client, localStorage)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> RefreshToken()
        {
            var valid = await _authStateProvider.IsAccessTokenStillValid();
            if (!valid)
            {
                var refreshToken = await _authStateProvider.GetRefreshToken();
                await _authStateProvider.DeleteRefreshToken();
                if (refreshToken != null)
                {
                    var accessToken = await _authStateProvider.GetAccessToken();
                    var response = await _client.RefreshAsync(new RefreshTokenRequest
                    {
                        AccessToken = accessToken,
                        RefreshToken = refreshToken

                    });
                    if(response != null)
                    {
                        await _authStateProvider.LogIn(response.AccessToken, response.RefreshToken);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
