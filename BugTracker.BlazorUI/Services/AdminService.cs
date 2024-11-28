using AutoMapper;
using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class AdminService : HttpClientService, IAdminService
    {
        private readonly IMapper _mapper;

        public AdminService(IClient client, ILocalStorageService localStorage, IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task AddRole(string userId, string roleName)
        {
            await _client.AddRoleAsync(userId, roleName);
        }
    }
}
