using BugTracker.Domain.Common;

namespace BugTracker.Domain
{
    public class IssuePriority : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
