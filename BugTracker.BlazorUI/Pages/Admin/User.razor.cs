using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Admin;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Admin
{
    public partial class User
    {
        [Inject] IAdminService AdminService { get; set; }
        private List<UserVM> Model { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            Model = await AdminService.GetUsers();
        }
    }
}
