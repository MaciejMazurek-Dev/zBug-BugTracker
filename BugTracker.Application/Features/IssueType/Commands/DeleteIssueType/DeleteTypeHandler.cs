using BugTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueType.Commands.DeleteIssueType
{
    public class DeleteTypeHandler : IRequestHandler<DeleteTypeCommand, Unit>
    {
        private readonly IIssueTypeRepository _issueTypeRepository;

        public DeleteTypeHandler(IIssueTypeRepository issueTypeRepository)
        {
            _issueTypeRepository = issueTypeRepository;
        }

        public async Task<Unit> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            var issueType = await _issueTypeRepository.GetByIdAsync(request.Id);
            await _issueTypeRepository.DeleteAsync(issueType);
            return Unit.Value;
        }
    }
}
