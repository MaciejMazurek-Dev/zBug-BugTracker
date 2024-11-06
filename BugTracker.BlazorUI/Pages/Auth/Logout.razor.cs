using BugTracker.BlazorUI.Services;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Auth
{
    public partial class Logout
    {
        [Inject]
        private NavigationManager NavManager { get; set; }
        [Inject]
        public AuthenticationService AuthService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AuthService.Logout();
            NavManager.NavigateTo("/");
        }
    }
}