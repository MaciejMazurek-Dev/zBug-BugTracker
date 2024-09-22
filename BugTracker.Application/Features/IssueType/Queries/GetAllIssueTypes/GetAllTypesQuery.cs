using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes
{
    public class GetAllTypesQuery : IRequest<List<IssueTypeDto>>
    {
    }
}
