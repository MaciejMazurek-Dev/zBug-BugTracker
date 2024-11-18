using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.IssueType;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class IssueTypeService : HttpClientService, IIssueTypeService
    {
        public IssueTypeService(IClient client, ILocalStorageService localStorageService) 
            : base(client, localStorageService)
        {
        }

        public Task CreateIssueType(IssueTypeVM issueType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIssueType(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IssueTypeVM>> GetAllIssueTypes()
        {
            List<IssueTypeVM> result = new List<IssueTypeVM>();
            var issueTypes = await _client.IssueTypeAllAsync();
            foreach(var type in issueTypes)
            {
                result.Add(new IssueTypeVM
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }
            return result;
        }

        public Task<IssueTypeVM> GetIssueTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssueType(int id, IssueTypeVM issueType)
        {
            throw new NotImplementedException();
        }
    }
}
