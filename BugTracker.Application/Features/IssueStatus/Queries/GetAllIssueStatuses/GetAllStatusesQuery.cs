using MediatR;

namespace BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses
{
    public class GetAllStatusesQuery : IRequest<List<IssueStatusesDto>>
    {
    }
}
