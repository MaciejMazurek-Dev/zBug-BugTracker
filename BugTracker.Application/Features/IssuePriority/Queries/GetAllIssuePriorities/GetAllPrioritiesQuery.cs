using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities
{
    public class GetAllPrioritiesQuery : IRequest<List<IssuePrioritiesDto>>
    {
    }
}
