using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Providers;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class AuthenticationService : HttpClientService, IAuthenticationService
    {
        private readonly CustomAuthStateProvider _customauthStateProvider;


        public AuthenticationService(
            IClient client, 
            ILocalStorageService localStorage,
            CustomAuthStateProvider customauthStateProvider)
            : base(client, localStorage)
        {
            _customauthStateProvider = customauthStateProvider;
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
                await _customauthStateProvider.LogIn();
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await _customauthStateProvider.LogOut();
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
