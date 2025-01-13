using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Auth
{
    public partial class Register
    {
        public RegisterVM RegisterModel { get; set; } = new();
        public string Message { get; set; } = string.Empty;
        [Inject] IAuthenticationService AuthenticationService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        protected async Task SubmitRegister()
        {
            var result = await AuthenticationService.RegisterAsync(RegisterModel);
            if(result.Success)
            {
                NavigationManager.NavigateTo("/issue");
            }
            Message = result.Message;
        }
    }
}
