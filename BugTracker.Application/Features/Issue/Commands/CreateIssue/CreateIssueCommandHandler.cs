using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;
using BugTracker.Application.Contracts.Identity;
using BugTracker.Domain;

namespace BugTracker.Application.Features.Issue.Commands.CreateIssue
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        private readonly IUserService _userService;

        public CreateIssueCommandHandler(IMapper mapper, IIssueRepository issueRepository, IUserService userService)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;
            _userService = userService;
        }

        public async Task<int> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateIssueValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            //TODO Fix validation
            /*
            if (!validatorResult.IsValid)
            {
                throw new BadRequestException("Invalid data in Issue", validatorResult);
            }
            */
            var issue = _mapper.Map<Domain.Issue>(request);

            issue.ReporterId = _userService.GetCurrentUserId();
            issue.IssueStatusId = 1;

            await _issueRepository.CreateAsync(issue);
            return issue.Id;
        }
    }
}
