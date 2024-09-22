using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses
{
    public class GetAllStatusesQuery : IRequest<List<IssueStatusDto>>
    {
    }
}
