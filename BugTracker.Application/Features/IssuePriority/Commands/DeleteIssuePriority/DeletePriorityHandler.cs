using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Application.Contracts.Persistence;

namespace BugTracker.Application.Features.IssuePriority.Commands.DeleteIssuePriority
{
    public class DeletePriorityHandler : IRequestHandler<DeletePriorityCommand, Unit>
    {
        private readonly IIssuePriorityRepository _issuePriorityRepository;
        public DeletePriorityHandler(IIssuePriorityRepository issuePriorityRepository)
        {
            _issuePriorityRepository = issuePriorityRepository;
        }

        public async Task<Unit> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = await _issuePriorityRepository.GetByIdAsync(request.Id);
            await _issuePriorityRepository.DeleteAsync(priority);
            return Unit.Value;
        }
    }
}
