using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetIssuePriorityById
{
    public class GetPriorityByIdQuery : IRequest<IssuePriorityDto>
    {
        public int Id { get; set; }
    }
}
