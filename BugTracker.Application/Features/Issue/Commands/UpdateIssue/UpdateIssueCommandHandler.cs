using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.Issue.Commands.UpdateIssue
{
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, Unit>
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IMapper _mapper;

        public UpdateIssueCommandHandler(IIssueRepository issueRepository, IMapper mapper)
        {
            _issueRepository = issueRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = _mapper.Map<Domain.Issue>(request);
            await _issueRepository.UpdateAsync(issue);
            return Unit.Value;
        }
    }
}
