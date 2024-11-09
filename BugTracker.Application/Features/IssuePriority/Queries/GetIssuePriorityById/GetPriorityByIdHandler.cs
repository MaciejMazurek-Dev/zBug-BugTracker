using BugTracker.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetIssuePriorityById
{
    public class GetPriorityByIdHandler : IRequestHandler<GetPriorityByIdQuery, IssuePriorityDetailsDto>
    {
        private readonly IIssuePriorityRepository _issuePriorityRepository;
        private readonly IMapper _mapper;
        public GetPriorityByIdHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _issuePriorityRepository = issuePriorityRepository;
            _mapper = mapper;
        }
        public async Task<IssuePriorityDetailsDto> Handle(GetPriorityByIdQuery request, CancellationToken cancellationToken)
        {
            var priority = await _issuePriorityRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<IssuePriorityDetailsDto>(priority);
            return result;
        }
    }
}
