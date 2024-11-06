using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Auth
{
    public partial class Login
    {
        public LoginVM Model { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            Model = new LoginVM();
        }

        public async Task SubmitLogin()
        {
            await AuthenticationService.LoginAsync(Model.Email, Model.Password);

        }
    }
}
