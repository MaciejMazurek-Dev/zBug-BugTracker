using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetIssueById
{
    public class GetIssueByIdQuery : IRequest<IssueByIdDto>
    {
        public int Id { get; set; }
    }
}
