using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace BugTracker.BlazorUI.Services.HttpClientBase
{
    public class HttpClientService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public HttpClientService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task AddJwtToken()
        {
            string? token = await _localStorage.GetItemAsync<string>("token");

            if (token != null)
            {
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
