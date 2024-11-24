using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Models.Identity;
using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Identity.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _userManager.Users
                .Select(u => new UserModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName
                }).ToListAsync();
            return users;
        }
    }
}
