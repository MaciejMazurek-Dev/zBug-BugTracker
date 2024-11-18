using MediatR;

namespace BugTracker.Application.Features.Issue.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest<int>
    {
        public int IssueTypeId { get; set; }
        public int IssuePriorityId { get; set; }
        public string Summary { get; set; } = string.Empty;
    }
}
