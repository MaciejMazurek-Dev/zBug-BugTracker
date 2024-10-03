using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;
using MediatR;

namespace BugTracker.Application.Features.Issue.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest<int>
    {

        public int ProjectId { get; set; }
        public int IssueTypeId { get; set; }
        public int IssueStatusId { get; set; }
        public int IssuePriopertyId { get; set; }
        public string Summary { get; set; } = string.Empty;
        public int ReporterId { get; set; }
        public int Assignee { get; set; }
    }
}
