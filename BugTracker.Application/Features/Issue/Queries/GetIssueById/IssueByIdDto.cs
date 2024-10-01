using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issue.Queries.GetIssueById
{
    public class IssueByIdDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public IssueTypeDto IssueType { get; set; }
        public IssueStatusDto IssueStatus { get; set; }
        public IssuePriorityDto IssuePriority { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int ReporterId { get; set; }
        public int Assignee { get; set; }
    }
}
