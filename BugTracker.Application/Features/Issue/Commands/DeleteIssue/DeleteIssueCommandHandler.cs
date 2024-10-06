using BugTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issue.Commands.DeleteIssue
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, Unit>
    {
        private readonly IIssueRepository _issueRepository;

        public DeleteIssueCommandHandler(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task<Unit> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = await _issueRepository.GetByIdAsync(request.Id);

            await _issueRepository.DeleteAsync(issue);
            return Unit.Value;
        }
    }
}
