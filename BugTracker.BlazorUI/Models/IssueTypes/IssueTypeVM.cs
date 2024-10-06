using System.ComponentModel.DataAnnotations;

namespace BugTracker.BlazorUI.Models.IssueTypes
{
    public class IssueTypeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
