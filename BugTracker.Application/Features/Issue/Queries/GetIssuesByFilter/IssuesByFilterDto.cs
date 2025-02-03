using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;

namespace BugTracker.Application.Features.Issue.Queries.GetIssuesByFilter
{
    public class IssuesByFilterDto
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public IssueTypeDto IssueType { get; set; }
        public IssueStatusDto IssueStatus { get; set; }
        public IssuePriorityDto IssuePriority { get; set; }
        public string ReporterId { get; set; }
        public string? AssigneeId { get; set; }
    }
}
