using System.ComponentModel.DataAnnotations;

namespace BugTracker.BlazorUI.Models.IssueStatus
{
    public class IssueStatusVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
