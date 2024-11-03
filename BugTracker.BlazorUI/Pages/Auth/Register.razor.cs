using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Auth
{
    public partial class Register
    {
        public RegisterVM Model { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            Model = new RegisterVM();
        }

        public async Task SubmitRegister()
        {
            await AuthenticationService.RegisterAsync(Model.FirstName, Model.LastName, Model.Email, Model.Password);
        }
    }
}
