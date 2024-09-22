using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueType.Queries.GetIssueTypeById
{
    public class GetTypeByIdQuery : IRequest<IssueTypeDto>
    {
        public int Id { get; set; }
    }
}
