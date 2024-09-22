using BugTracker.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueStatus.Queries.GetIssueStatusById
{
    public class GetStatusByIdQuery : IRequest<IssueStatusDto>
    {
        public int Id { get; set; }
    }
}
