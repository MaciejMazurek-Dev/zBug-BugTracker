using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.Issue.Commands.CreateIssue
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;

        public CreateIssueCommandHandler(IMapper mapper, IIssueRepository issueRepository)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;
        }

        public async Task<Unit> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = _mapper.Map<Domain.Issue>(request);
            await _issueRepository.CreateAsync(issue);
            return Unit.Value;
        }
    }
}
