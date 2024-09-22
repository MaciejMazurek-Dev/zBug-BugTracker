using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Commands.DeleteIssuePriority
{
    public class DeletePriorityCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
