using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueType.Commands.DeleteIssueType
{
    public class DeleteTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
