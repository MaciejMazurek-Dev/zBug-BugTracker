using AutoMapper;
using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.User;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class UserService : HttpClientService, IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IClient client, ILocalStorageService localStorage, IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<UserVM>> GetUsers()
        {
            var users = await _client.UserAsync();
            return _mapper.Map<List<UserVM>>(users);
        }
    }
}
