using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.User;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Admin
{
    public partial class User
    {
        [Inject] IUserService UserService { get; set; }
        private List<UserVM> Users { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            Users = await UserService.GetUsers();
        }
    }
}
