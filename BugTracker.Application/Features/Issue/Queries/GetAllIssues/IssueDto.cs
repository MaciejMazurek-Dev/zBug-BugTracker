using BugTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issue.Queries.GetAllIssues
{
    public class IssueDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public IssueType? IssueType { get; set; }
        public IssueStatus? IssueStatus { get; set; }
        public IssuePriority? IssuePriority { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int ReporterId { get; set; }
        public int Assignee { get; set; }

    }
}
