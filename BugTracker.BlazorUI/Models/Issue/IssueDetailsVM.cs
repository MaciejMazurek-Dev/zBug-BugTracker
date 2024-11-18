using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Models.IssueStatus;
using BugTracker.BlazorUI.Models.IssueType;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.BlazorUI.Models.Issue
{
    public class IssueDetailsVM
    {
        public int Id { get; set; }

        [Required]
        public IssueTypeVM IssueType { get; set; }

        [Required]
        public IssueStatusVM IssueStatus { get; set; }

        [Required]
        public IssuePriorityVM IssuePriority { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string ReporterId { get; set; }

        public string? Assignee { get; set; }
    }
}
