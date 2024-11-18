using System.ComponentModel.DataAnnotations;

namespace BugTracker.BlazorUI.Models.IssueType
{
    public class IssueTypeVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
