using BugTracker.Domain.Common;

namespace BugTracker.Domain
{
    public class Issue : BaseEntity
    {
        public IssueType IssueType { get; set; }
        public int IssueTypeId { get; set; }

        public IssueStatus IssueStatus { get; set; }
        public int IssueStatusId { get; set; }

        public IssuePriority IssuePriority { get; set; }
        public int IssuePriorityId { get; set; }

        public string Summary { get; set; } = string.Empty;
        public string ReporterId { get; set; } = string.Empty;
        public string? AssigneeId { get; set; } = null;
    }
}
