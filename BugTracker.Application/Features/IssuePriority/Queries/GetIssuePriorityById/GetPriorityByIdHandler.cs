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
    public class GetPriorityByIdHandler : IRequestHandler<GetPriorityByIdQuery, IssuePriorityByIdDto>
    {
        private readonly IIssuePriorityRepository _issuePriorityRepository;
        private readonly IMapper _mapper;
        public GetPriorityByIdHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _issuePriorityRepository = issuePriorityRepository;
            _mapper = mapper;
        }
        public async Task<IssuePriorityByIdDto> Handle(GetPriorityByIdQuery request, CancellationToken cancellationToken)
        {
            var priority = await _issuePriorityRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<IssuePriorityByIdDto>(priority);
            return result;
        }
    }
}
