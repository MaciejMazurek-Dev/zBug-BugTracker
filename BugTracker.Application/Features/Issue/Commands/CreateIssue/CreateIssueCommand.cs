using MediatR;

namespace BugTracker.Application.Features.Issue.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest<Unit>
    {
        public int ProjectId { get; set; }
        public int IssueTypeId { get; set; }
        public int IssueStatusId { get; set; }
        public int IssuePriopertyId { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int ReporterId { get; set; }
        public int Assignee { get; set; }
    }
}
