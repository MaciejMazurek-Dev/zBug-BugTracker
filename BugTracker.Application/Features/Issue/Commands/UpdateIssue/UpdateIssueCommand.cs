using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BugTracker.Application.Features.Issue.Commands.UpdateIssue
{
    public class UpdateIssueCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
