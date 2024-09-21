using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;

namespace BugTracker.Application.Features.IssuePriority.Queries.GetIssuePriorityById
{
    public class GetIssuePriorityByIdHandler : IRequestHandler<GetIssuePriorityByIdQuery, IssuePriorityDto>
    {
        private readonly IIssuePriorityRepository _issuePriorityRepository;
        private readonly IMapper _mapper;
        public GetIssuePriorityByIdHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _issuePriorityRepository = issuePriorityRepository;
            _mapper = mapper;
        }
        public async Task<IssuePriorityDto> Handle(GetIssuePriorityByIdQuery request, CancellationToken cancellationToken)
        {
            var priority = await _issuePriorityRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<IssuePriorityDto>(priority);
            return result;
        }
    }
}
