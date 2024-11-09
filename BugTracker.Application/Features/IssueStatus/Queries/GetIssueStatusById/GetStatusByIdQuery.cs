using MediatR;

namespace BugTracker.Application.Features.IssueStatus.Queries.GetIssueStatusById
{
    public class GetStatusByIdQuery : IRequest<IssueStatusDetailsDto>
    {
        public int Id { get; set; }
    }
}
