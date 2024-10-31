using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Providers;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly BlazorAuthenticationStateProvider _blazorAuthenticationStateProvider;

        public AuthenticationService(IClient client, 
            ILocalStorageService localStorage,
            BlazorAuthenticationStateProvider blazorAuthenticationStateProvider) 
            : base(client, localStorage)
        {
            _blazorAuthenticationStateProvider = blazorAuthenticationStateProvider;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                Email = email,
                Password = password
            };

            LoginResponse loginResponse = await _client.LoginAsync(loginRequest);

            if(loginResponse.Token != string.Empty)
            {
                await _localStorage.SetItemAsync("token", loginResponse.Token);
                await _blazorAuthenticationStateProvider.LogIn();
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await _blazorAuthenticationStateProvider.LogOut();
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            RegisterRequest registerRequest = new RegisterRequest()
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = password
            };

            RegisterResponse registerResponse = await _client.RegisterAsync(registerRequest);
            if(!string.IsNullOrEmpty(registerResponse.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
