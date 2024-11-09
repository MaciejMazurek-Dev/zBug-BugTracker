using MediatR;

namespace BugTracker.Application.Features.IssueType.Queries.GetIssueTypeById
{
    public class GetTypeByIdQuery : IRequest<IssueTypeDetailsDto>
    {
        public int Id { get; set; }
    }
}
