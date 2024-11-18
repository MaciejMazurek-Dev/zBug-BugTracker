using AutoMapper;
using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetAllIssues
{
    public class GetAllIssuesHandler :
        IRequestHandler<GetAllIssuesQuery, List<IssueDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        private readonly IUserService _userService;

        public GetAllIssuesHandler(IMapper mapper, IIssueRepository issueRepository, IUserService userService)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;
            _userService = userService;
        }
        public async Task<List<IssueDto>> Handle(GetAllIssuesQuery request, CancellationToken cancellationToken)
        {
            var issues = await _issueRepository.GetAllIssues();

            return _mapper.Map<List<IssueDto>>(issues);
        }
    }
}
