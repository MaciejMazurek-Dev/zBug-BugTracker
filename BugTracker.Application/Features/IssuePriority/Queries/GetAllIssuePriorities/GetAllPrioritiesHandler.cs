using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities
{
    public class GetAllPrioritiesHandler : IRequestHandler<GetAllPrioritiesQuery, List<IssuePrioritiesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssuePriorityRepository _issuePriorityRepository;

        public GetAllPrioritiesHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _mapper = mapper;
            _issuePriorityRepository = issuePriorityRepository;
        }
        public async Task<List<IssuePrioritiesDto>> Handle(GetAllPrioritiesQuery request, CancellationToken cancellationToken)
        {
            var priorities = await _issuePriorityRepository.GetAllAsync();
            var result = _mapper.Map<List<IssuePrioritiesDto>>(priorities);
            return result;
        }
    }
}
