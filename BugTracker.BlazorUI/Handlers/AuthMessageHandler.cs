using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace BugTracker.BlazorUI.Handlers
{
    public class AuthMessageHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorageService;

        public AuthMessageHandler(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorageService.GetItemAsync<string>("token");
            if(!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
