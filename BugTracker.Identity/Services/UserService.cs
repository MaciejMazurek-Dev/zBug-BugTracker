﻿using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Models.Identity;
using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BugTracker.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue("uid");
        }

        public async Task<UserModel> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _userManager.Users
                .Select(u => new UserModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    InternalUserId = ("BTU-00" + u.InternalUserId.ToString())
                }).ToListAsync();
            return users;
        }
    }
}
