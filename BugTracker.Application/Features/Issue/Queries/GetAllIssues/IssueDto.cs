using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;

namespace BugTracker.Application.Features.Issue.Queries.GetAllIssues
{
    public class IssueDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public IssueTypeDto IssueType { get; set; }
        public int IssueTypeId { get; set; }
        public IssueStatusDto IssueStatus { get; set; }
        public int IssueStatusId { get; set; }
        public IssuePriorityDto IssuePriority { get; set; }
        public int IssuePriopertyId { get; set; }
        public int ReporterId { get; set; }
        public int Assignee { get; set; }
    }
}
