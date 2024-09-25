using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority
{
    public class CreatePriorityCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
