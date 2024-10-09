using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;
using BugTracker.Application.Exceptions;

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
            var validator = new CreateIssueValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new BadRequestException("Invalid data in Issue", validatorResult);
            }

            var issue = _mapper.Map<Domain.Issue>(request);
            await _issueRepository.CreateAsync(issue);
            return Unit.Value;
        }
    }
}
