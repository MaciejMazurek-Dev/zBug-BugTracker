using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Role;
using BugTracker.BlazorUI.Models.User;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Admin
{
    public partial class Edit
    {
        protected RoleVM RoleModel { get; set; } = new();
        [Inject] IAdminService AdminService { get; set; }
        [Parameter] public string Id { get; set; }
        

        protected async Task AddRole()
        {
            await AdminService.AddRole(Id, RoleModel.Name);
        }
    }
}
