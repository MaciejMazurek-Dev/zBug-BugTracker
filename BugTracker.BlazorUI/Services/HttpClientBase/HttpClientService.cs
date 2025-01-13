using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Providers;
using System.Net.Http.Headers;

namespace BugTracker.BlazorUI.Services.HttpClientBase
{
    public class HttpClientService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public HttpClientService(IClient client, 
            ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
            
        }

        public async Task AddJwtToken()
        {
            string? token = await _localStorage.GetItemAsync<string>(CustomAuthStateProvider.ACCESS_TOKEN_NAME);

            if (token != null)
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }


        public Response<T> ConvertApiException<T>(ApiException ex)
        {
            switch (ex.StatusCode)
            {
                case 404:
                    return new Response<T>
                    {
                        Success = false,
                        StatusCode = ex.StatusCode,
                        Message = "Data not found.",
                    };

                case 401:
                    return new Response<T>
                    {
                        Success = false,
                        StatusCode = ex.StatusCode,
                        Message = "You’re not authorized to access this resource"
                    };

                default:
                    return new Response<T>
                    {
                        Success = false,
                        StatusCode = ex.StatusCode,
                        Message = "An unknown error occurred – please try again later."
                    };
            }
        }
    }
}
