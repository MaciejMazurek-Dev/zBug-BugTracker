using BugTracker.Domain.Common;

namespace BugTracker.Domain
{
    public class IssueStatus :BaseEntity
    {
        public string Name { get; set; } = string.Empty; 
    }
}
