namespace BugTracker.BlazorUI.Services.HttpClientBase
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
