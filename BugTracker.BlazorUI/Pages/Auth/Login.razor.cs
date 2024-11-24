using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Auth
{
    public partial class Login
    {
        public LoginVM Model { get; set; } = new();
        public string Message { get; set; } = string.Empty;
        [Inject]IAuthenticationService AuthenticationService { get; set; }
        [Inject]NavigationManager NavigationManager { get; set; }

        public async Task SubmitLogin()
        {
            bool result = await AuthenticationService.LoginAsync(Model);
            if(result)
            {
                NavigationManager.NavigateTo("/issue");
            }
            Message = "Wrong email or password.";
        } 
    }
}
