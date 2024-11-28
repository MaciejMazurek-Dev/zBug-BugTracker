using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Models.Identity;
using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BugTracker.Identity.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<bool>AddRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
