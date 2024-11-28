using AutoMapper;
using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Role;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class RoleService : HttpClientService, IRoleService
    {
        private readonly IMapper _mapper;

        public RoleService(IClient client, 
            ILocalStorageService localStorage,
            IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<RoleVM>> GetAllRoles()
        {
            var roles = await _client.GetAllRolesAsync();

            return _mapper.Map<List<RoleVM>>(roles);
        }

        public async Task<List<RoleVM>> GetRoles(string userId)
        {
            var roles = await _client.GetUserRolesAsync(userId);
            return _mapper.Map<List<RoleVM>>(roles);
        }
    }
}
