using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetIssuePriorityById
{
    public class GetIssuePriorityByIdQuery : IRequest<IssuePriorityDto>
    {
        public int Id { get; set; }
    }
}
