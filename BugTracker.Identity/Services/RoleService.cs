using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Models.Identity;
using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace BugTracker.Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<List<RoleModel>> GetRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleModel> result = new();
            foreach (var role in userRoles)
            {
                result.Add(new RoleModel { Name = role });
            }
            return result;
        }

        public async Task<List<RoleModel>> GetAllRoles()
        {
            var roles = await Task.FromResult(_roleManager.Roles.ToList());
            List<RoleModel> result = new();
            foreach (var role in roles)
            {
                result.Add(new RoleModel { Name = role.Name });
            }
            return result;
        }
    }
}
