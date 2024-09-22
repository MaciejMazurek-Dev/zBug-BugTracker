using BugTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueStatus.Commands.DeleteIssueStatus
{
    public class DeleteStatusHandler :IRequestHandler<DeleteStatusCommand, Unit>
    {
        private readonly IIssueStatusRepository _issueStatusRepository;

        public DeleteStatusHandler(IIssueStatusRepository issueStatusRepository)
        {
            _issueStatusRepository = issueStatusRepository;
        }

        public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var status = await _issueStatusRepository.GetByIdAsync(request.Id);
            await _issueStatusRepository.DeleteAsync(status);
            
            return Unit.Value;
        }
    }
}
