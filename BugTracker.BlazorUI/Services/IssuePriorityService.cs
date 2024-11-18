using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class IssuePriorityService : HttpClientService, IIssuePriorityService
    {
        public IssuePriorityService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
        }

        public Task CreateIssuePriority(IssuePriorityVM issuePriority)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIssuePriority(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IssuePriorityVM>> GetAllIssuePriorities()
        {
            List<IssuePriorityVM> result = new List<IssuePriorityVM>();
            var issuePriorities =  await _client.IssuePriorityAllAsync();
            foreach(var priority in issuePriorities)
            {
                result.Add(new IssuePriorityVM
                {
                    Id = priority.Id,
                    Name = priority.Name
                });
            }
            return result;
        }

        public Task<IssuePriorityVM> GetIssuePriorityById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssuePriority(int id, IssuePriorityVM issuePriority)
        {
            throw new NotImplementedException();
        }
    }
}
