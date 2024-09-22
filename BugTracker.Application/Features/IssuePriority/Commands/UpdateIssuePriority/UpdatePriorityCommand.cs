using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace BugTracker.Application.Features.IssuePriority.Commands.UpdateIssuePriority
{
    public class UpdatePriorityCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
    }
}
