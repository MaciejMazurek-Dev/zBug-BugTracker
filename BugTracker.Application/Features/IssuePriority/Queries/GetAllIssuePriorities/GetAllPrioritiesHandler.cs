using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities
{
    public class GetAllIssuePrioritiesHandler : IRequestHandler<GetAllIssuePrioritiesQuery, List<IssuePriorityDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssuePriorityRepository _issuePriorityRepository;

        public GetAllIssuePrioritiesHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _mapper = mapper;
            _issuePriorityRepository = issuePriorityRepository;
        }
        public async Task<List<IssuePriorityDto>> Handle(GetAllIssuePrioritiesQuery request, CancellationToken cancellationToken)
        {
            var priorities = await _issuePriorityRepository.GetAllAsync();
            var result = _mapper.Map<List<IssuePriorityDto>>(priorities);
            return result;
        }
    }
}
