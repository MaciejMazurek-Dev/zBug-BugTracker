using BugTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetIssuePriorityById
{
    public class IssuePriorityDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Domain.IssueType? IssueType { get; set; }
        public Domain.IssueStatus? IssueStatus { get; set; }
        public Domain.IssuePriority? IssuePriority { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int ReporterId { get; set; }
        public int Assignee { get; set; }
    }
}
