using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority
{
    public class CreatePriorityCommandHandler : IRequestHandler<CreatePriorityCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IIssuePriorityRepository _issuePriorityRepository;

        public CreatePriorityCommandHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _mapper = mapper;
            _issuePriorityRepository = issuePriorityRepository;
        }

        public async Task<int> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
        {
            var issuePriority = _mapper.Map<Domain.IssuePriority>(request);
            await _issuePriorityRepository.CreateAsync(issuePriority);
            return issuePriority.Id;
        }
    }
}
