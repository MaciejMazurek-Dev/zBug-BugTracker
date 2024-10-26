using Blazored.LocalStorage;

namespace BugTracker.BlazorUI.Services.Base
{
    public class BaseHttpService
    {
        protected readonly IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public Response<Guid> ConvertApiExceptions(ApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>()
                {
                    Message = "Invalid data",
                    ValidationErrors = ex.Response,
                    Success = false
                };
            }
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>()
                {
                    Message = "Record not found",
                    ValidationErrors = ex.Response,
                    Success = false
                };
            }
            else
            {
                return new Response<Guid>()
                {
                    Message = "Something went wrong, please try later",
                    ValidationErrors = ex.Response,
                    Success = false
                };
            }
        }
    }
}
