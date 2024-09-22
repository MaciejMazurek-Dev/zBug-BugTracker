using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueType.Commands.UpdateIssueType
{
    public class UpdateTypeCommand : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
