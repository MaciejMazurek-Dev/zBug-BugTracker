using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BugTracker.Application.Features.IssueStatus.Commands.CreateIssueStatus
{
    public class CreateStatusCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
