using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BugTracker.Application.Features.Issue.Commands.UpdateIssue
{
    public class UpdateIssueCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int IssueTypeId { get; set; }
        public int IssuePriorityId { get; set; }
        public int IssueStatusId { get; set; }
        public string Description { get; set; } 
        public string Summary { get; set; } 
        public string ReporterId { get; set; } 
        public string? AssigneeId { get; set; } 
    }
}
