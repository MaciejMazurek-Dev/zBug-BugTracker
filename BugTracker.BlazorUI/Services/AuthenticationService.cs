using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        public AuthenticationService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
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

                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
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
