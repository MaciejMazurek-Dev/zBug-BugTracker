using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetIssuePriorityById
{
    public class GetPriorityByIdQuery : IRequest<IssuePriorityDetailsDto>
    {
        public int Id { get; set; }
    }
}
