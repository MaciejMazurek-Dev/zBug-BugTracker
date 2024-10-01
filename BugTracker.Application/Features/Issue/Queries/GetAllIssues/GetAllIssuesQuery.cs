using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issue.Queries.GetAllIssues
{
    public class GetAllIssuesQuery : IRequest<List<IssueDto>>
    {
    }
    
}
