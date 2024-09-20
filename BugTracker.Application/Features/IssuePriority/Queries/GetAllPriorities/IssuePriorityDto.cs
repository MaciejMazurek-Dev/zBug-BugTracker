using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetAllPriorities
{
    public class IssuePriorityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
