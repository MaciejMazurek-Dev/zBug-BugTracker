using MediatR;

namespace BugTracker.Application.Features.IssueType.Queries.GetIssueTypeById
{
    public class GetTypeByIdQuery : IRequest<IssueTypeDto>
    {
        public int Id { get; set; }
    }
}
