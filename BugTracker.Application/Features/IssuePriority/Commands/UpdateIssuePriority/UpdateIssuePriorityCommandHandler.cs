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
    public class UpdateIssuePriorityCommandHandler : IRequestHandler<UpdateIssuePriorityCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IIssuePriorityRepository _issuePriorityRepository;

        public UpdateIssuePriorityCommandHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _mapper = mapper;
            _issuePriorityRepository = issuePriorityRepository;
        }
        public async Task<Unit> Handle(UpdateIssuePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = _mapper.Map<Domain.IssuePriority>(request);
            await _issuePriorityRepository.UpdateAsync(priority);
            return Unit.Value;
        }
    }
}
