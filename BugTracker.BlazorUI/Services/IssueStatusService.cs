using AutoMapper;
using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.IssueStatus;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class IssueStatusService : HttpClientService, IIssueStatusService
    {
        private readonly IMapper _mapper;

        public IssueStatusService(IClient client, ILocalStorageService localStorage, IMapper mapper) 
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task CreateIssueStatus(IssueStatusVM issueStatus)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIssueStatus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IssueStatusVM>> GetAllIssueStatuses()
        {
            var statuses = await _client.IssueStatusAllAsync();
            return _mapper.Map<List<IssueStatusVM>>(statuses);
        }

        public Task<IssueStatusVM> GetIssueStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIssueStatus(int id, IssueStatusVM issueStatus)
        {
            throw new NotImplementedException();
        }
    }
}
