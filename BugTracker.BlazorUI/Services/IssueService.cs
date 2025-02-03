using AutoMapper;
using Blazored.LocalStorage;
using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.Services
{
    public class IssueService : HttpClientService, IIssueService
    {
        private readonly IMapper _mapper;

        public IssueService(IClient client, ILocalStorageService localStorageService, IMapper mapper) 
            : base(client, localStorageService)
        {
            _mapper = mapper;
        }
        public async Task<Response<List<IssueVM>>> GetAllIssues()
        {
            try
            {
                var issues = await _client.IssueAllAsync();
                var result = _mapper.Map<List<IssueVM>>(issues);
                return new Response<List<IssueVM>> { Data = result };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<List<IssueVM>>(ex);
            }
        }
        public async Task<Response<IssueDetailsVM>> GetIssueById(int id)
        {
            try
            {
                var issue = await _client.IssueGETAsync(id);
                var result = _mapper.Map<IssueDetailsVM>(issue);
                return new Response<IssueDetailsVM> { Data = result };
            }
            catch(ApiException ex)
            {
                return ConvertApiException<IssueDetailsVM>(ex);
            }
            
        }
        public async Task<Response<bool>> CreateIssue(CreateIssueVM issue)
        {
            try
            {
                var command = _mapper.Map<CreateIssueCommand>(issue);
                await _client.IssuePOSTAsync(command);
                return new Response<bool>();
            }
            catch (ApiException ex)
            {
                return ConvertApiException<bool>(ex);
            }
        }
        public async Task<Response<bool>> DeleteIssue(int id)
        {
            try
            {
                await _client.IssueDELETEAsync(id);
                return new Response<bool>();
            }
            catch (ApiException ex)
            {
                return ConvertApiException<bool>(ex);
            }
        }
        public async Task<Response<bool>> UpdateIssue(IssueDetailsVM issue)
        {
            try
            {
                var issueCommand = _mapper.Map<UpdateIssueCommand>(issue);
                await _client.IssuePUTAsync(issueCommand);
                return new Response<bool>();
            }
            catch (ApiException ex)
            {
                return ConvertApiException<bool>(ex);
            }
        }
        public async Task<Response<List<IssueVM>>> GetIssuesByFilter(int? type, int? status, int? priority)
        {
            try
            {
                var issues = await _client.FiltersAsync(type, status, priority);
                var result = _mapper.Map<List<IssueVM>>(issues);
                return new Response<List<IssueVM>> { Data = result };
            }
            catch (ApiException ex)
            {
                return ConvertApiException<List<IssueVM>> (ex);
            }
        }
    }
}
