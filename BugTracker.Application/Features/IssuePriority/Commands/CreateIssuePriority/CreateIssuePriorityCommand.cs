using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority
{
    public class CreateIssuePriorityCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
