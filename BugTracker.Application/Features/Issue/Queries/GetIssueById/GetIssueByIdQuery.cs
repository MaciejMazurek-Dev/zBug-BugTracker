using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetIssueById
{
    public class GetIssueByIdQuery : IRequest<IssueDetailsDto>
    {
        public int Id { get; set; }
    }
}
