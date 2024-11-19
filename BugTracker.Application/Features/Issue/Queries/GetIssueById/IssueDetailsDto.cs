using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;

namespace BugTracker.Application.Features.Issue.Queries.GetIssueById
{
    public class IssueDetailsDto
    {
        public int Id { get; set; }
        public IssueTypeDto IssueType { get; set; }
        public IssueStatusDto IssueStatus { get; set; }
        public IssuePriorityDto IssuePriority { get; set; }
        public string Summary { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ReporterId { get; set; }
        public string? Assignee { get; set; }
    }
}
