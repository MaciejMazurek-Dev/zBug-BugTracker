using BugTracker.Domain.Common;

namespace BugTracker.Domain
{
    public class Issue : BaseEntity
    {
        public int ProjectId { get; set; }
        public IssueType? IssueType { get; set; }
        public IssueStatus? IssueStatus { get; set; }
        public IssuePriority? IssuePriority { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int ReporterId { get; set; }
        public int Assignee { get; set; }
    }
}
