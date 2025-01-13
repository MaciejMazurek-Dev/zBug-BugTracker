using AutoMapper;
using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Authentication;
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

        public async Task<Response<LoginResponse>> LoginAsync(LoginVM loginVM)
        {
            try
            {
                var loginRequest = _mapper.Map<LoginRequest>(loginVM);
                LoginResponse loginResponse = await _client.LoginAsync(loginRequest);
                if (loginResponse.AccessToken != string.Empty &&
                    loginResponse.RefreshToken != string.Empty)
                {
                    await _customauthStateProvider.LogIn(loginResponse.AccessToken, loginResponse.RefreshToken);
                }
                return new Response<LoginResponse> { Data = loginResponse };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<LoginResponse>(ex);
            }
        }

        public async Task Logout()
        {
            await _customauthStateProvider.LogOut();
        }

        public async Task<Response<RegisterResponse>> RegisterAsync(RegisterVM registerVM)
        {
            try
            {
                var registerRequest = _mapper.Map<RegisterRequest>(registerVM);
                RegisterResponse registerResponse = await _client.RegisterAsync(registerRequest);
                if (!string.IsNullOrEmpty(registerResponse.UserId))
                {
                    return new Response<RegisterResponse> { Data = registerResponse };
                }
                return new Response<RegisterResponse> { Message = "Wrong email or password." };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<RegisterResponse>(ex);
            }
        }
    }
}
