using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BugTracker.BlazorUI.Pages
{
    public partial class Index : ComponentBase
    {

        [Inject]
        private BlazorAuthenticationStateProvider AuthStateProvider { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }


        protected async override Task OnInitializedAsync()
        {
            AuthenticationState authState = await AuthStateProvider.GetAuthenticationStateAsync();
            if (authState == null)
            {
                Login();
            }
        }

        protected async Task Logout()
        {
            await AuthenticationService.Logout();
        }

        protected void Login()
        {
            NavigationManager.NavigateTo("login");
        }
        
        protected void Register()
        {
            NavigationManager.NavigateTo("register");
        }
        
    }
}
