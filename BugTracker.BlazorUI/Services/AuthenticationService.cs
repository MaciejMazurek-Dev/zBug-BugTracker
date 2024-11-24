using AutoMapper;
using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Authentication;
using BugTracker.BlazorUI.Pages.Auth;
using BugTracker.BlazorUI.Providers;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class AuthenticationService : HttpClientService, IAuthenticationService
    {
        private readonly CustomAuthStateProvider _customauthStateProvider;
        private readonly IMapper _mapper;
        public AuthenticationService(
            IClient client, 
            ILocalStorageService localStorage,
            CustomAuthStateProvider customauthStateProvider,
            IMapper mapper)
            : base(client, localStorage)
        {
            _customauthStateProvider = customauthStateProvider;
            _mapper = mapper;
        }

        public async Task<bool> LoginAsync(LoginVM loginVM)
        {
            var loginRequest = _mapper.Map<LoginRequest>(loginVM);
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

        public async Task<bool> RegisterAsync(RegisterVM registerVM)
        {
            var registerRequest = _mapper.Map<RegisterRequest>(registerVM);
            RegisterResponse registerResponse = await _client.RegisterAsync(registerRequest);
            if(!string.IsNullOrEmpty(registerResponse.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
