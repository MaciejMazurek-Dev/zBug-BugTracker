using MediatR;

namespace BugTracker.Application.Features.Issue.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest<int>
    {
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int ReporterId { get; set; }
        public int Assignee { get; set; }
    }
}
