namespace BugTracker.BlazorUI.Services.HttpClientBase
{
    public class Response<T>
    {
        public bool Success { get; set; } = true;
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
