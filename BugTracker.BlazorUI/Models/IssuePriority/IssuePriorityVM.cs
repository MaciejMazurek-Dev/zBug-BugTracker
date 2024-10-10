using System.ComponentModel.DataAnnotations;

namespace BugTracker.BlazorUI.Models.IssuePriority
{
    public class IssuePriorityVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
