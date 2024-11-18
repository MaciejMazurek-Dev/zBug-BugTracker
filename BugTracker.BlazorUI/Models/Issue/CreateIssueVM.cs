using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Models.IssueStatus;
using BugTracker.BlazorUI.Models.IssueType;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.BlazorUI.Models.Issue
{
    public class CreateIssueVM
    {
        [Required]
        public int IssueTypeId { get; set; }

        [Required]
        public int IssuePriorityId { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}
