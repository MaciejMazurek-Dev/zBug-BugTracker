using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages
{
    public partial class Index
    {

        [Inject]
        private CustomAuthStateProvider CustomAuthStateProvider{ get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }


        protected async override Task OnInitializedAsync()
        {
            await CustomAuthStateProvider.GetAuthenticationStateAsync();
        }

        protected async Task Logout()
        {
            await AuthenticationService.Logout();
        }

        protected void Login()
        {
            NavigationManager.NavigateTo("/auth/login");
        }
        
        protected void Register()
        {
            NavigationManager.NavigateTo("/auth/register");
        }
        
    }
}
