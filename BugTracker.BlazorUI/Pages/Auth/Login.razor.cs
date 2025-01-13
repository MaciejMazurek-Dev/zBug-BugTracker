using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Auth
{
    public partial class Login
    {
        public LoginVM LoginModel { get; set; } = new();
        public string Message { get; set; } = string.Empty;
        [Inject]IAuthenticationService AuthenticationService { get; set; }
        [Inject]NavigationManager NavigationManager { get; set; }

        public async Task SubmitLogin()
        {
            var result = await AuthenticationService.LoginAsync(LoginModel);
            if(result.Success)
            {
                NavigationManager.NavigateTo("/issue");
            }
            Message = result.Message;
        } 
    }
}
