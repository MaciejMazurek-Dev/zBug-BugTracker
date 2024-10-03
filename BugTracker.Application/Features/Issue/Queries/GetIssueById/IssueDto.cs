using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;

namespace BugTracker.Application.Features.Issue.Queries.GetIssueById
{
    public class IssueDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public IssueTypesDto IssueType { get; set; }
        public int IssueTypeId { get; set; }
        public IssueStatusesDto IssueStatus { get; set; }
        public int IssueStatusId { get; set; }
        public IssuePrioritiesDto IssuePriority { get; set; }
        public int IssuePriopertyId { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int ReporterId { get; set; }
        public int Assignee { get; set; }
    }
}
