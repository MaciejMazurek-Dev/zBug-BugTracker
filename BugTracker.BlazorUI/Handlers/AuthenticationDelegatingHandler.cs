using BugTracker.BlazorUI.Contracts;

namespace BugTracker.BlazorUI.Handlers
{
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public AuthenticationDelegatingHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var tokenRefreshService = _serviceProvider.GetRequiredService<ITokenRefreshService>();
            await tokenRefreshService.RefreshToken();
            return await base.SendAsync(request, cancellationToken);
        }
    }
}

