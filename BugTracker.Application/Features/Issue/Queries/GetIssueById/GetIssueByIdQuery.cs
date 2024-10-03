using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetIssueById
{
    public class GetIssueByIdQuery : IRequest<IssueDto>
    {
        public int Id { get; set; }
    }
}
