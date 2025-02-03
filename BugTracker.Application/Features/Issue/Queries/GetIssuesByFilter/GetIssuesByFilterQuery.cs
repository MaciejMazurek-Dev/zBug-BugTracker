using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetIssuesByFilter
{
    public class GetIssuesByFilterQuery : IRequest<List<IssuesByFilterDto>> 
    {
        public int? IssueTypeId { get; set; }
        public int? IssueStatusId { get; set; }
        public int? IssuePriorityId { get; set; }
    }
}
