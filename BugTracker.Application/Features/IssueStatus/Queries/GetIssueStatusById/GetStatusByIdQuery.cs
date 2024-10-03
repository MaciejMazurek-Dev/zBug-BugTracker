using MediatR;

namespace BugTracker.Application.Features.IssueStatus.Queries.GetIssueStatusById
{
    public class GetStatusByIdQuery : IRequest<IssueStatusDto>
    {
        public int Id { get; set; }
    }
}
