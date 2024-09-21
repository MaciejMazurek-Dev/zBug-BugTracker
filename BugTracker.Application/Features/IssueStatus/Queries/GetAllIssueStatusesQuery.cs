using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BugTracker.Application.Features.IssueStatus.Queries
{
    public class GetAllIssueStatusesQuery : IRequest<List<IssueStatusDto>>
    {
    }
}
