using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.IssueTypes;
using BugTracker.BlazorUI.Services.Base;

namespace BugTracker.BlazorUI.Services
{
    public class IssueTypeService : BaseHttpService, IIssueTypeService
    {
        public IssueTypeService(IClient client) : base(client)
        {
        }

        public Task<Response<Guid>> CreateIssueType(IssueTypeVM issueType)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> DeleteIssueType(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IssueTypeVM>> GetAllIssueTypes()
        {
            throw new NotImplementedException();
        }

        public Task<IssueTypeVM> GetIssueTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Guid>> UpdateIssueType(int id, IssueTypeVM issueType)
        {
            throw new NotImplementedException();
        }
    }
}
