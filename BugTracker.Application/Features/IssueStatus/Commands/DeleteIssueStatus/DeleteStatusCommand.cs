using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueStatus.Commands.DeleteIssueStatus
{
    public class DeleteStatusCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
