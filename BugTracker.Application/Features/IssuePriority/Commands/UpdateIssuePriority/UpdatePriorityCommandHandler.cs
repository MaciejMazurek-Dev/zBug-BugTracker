using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Commands.UpdateIssuePriority
{
    public class UpdatePriorityCommandHandler : IRequestHandler<UpdatePriorityCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IIssuePriorityRepository _issuePriorityRepository;

        public UpdatePriorityCommandHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _mapper = mapper;
            _issuePriorityRepository = issuePriorityRepository;
        }
        public async Task<Unit> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = _mapper.Map<Domain.IssuePriority>(request);
            await _issuePriorityRepository.UpdateAsync(priority);
            return Unit.Value;
        }
    }
}
