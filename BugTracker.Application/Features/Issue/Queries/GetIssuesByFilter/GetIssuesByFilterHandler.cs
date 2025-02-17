using AutoMapper;
using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetIssuesByFilter
{
    public class GetIssuesByFilterHandler : IRequestHandler<GetIssuesByFilterQuery, List<IssuesByFilterDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        private readonly IUserService _userService;
        public GetIssuesByFilterHandler(IMapper mapper, IIssueRepository issueRepository, IUserService userService)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;
            _userService = userService;
        }

        public async Task<List<IssuesByFilterDto>> Handle(GetIssuesByFilterQuery request, CancellationToken cancellationToken)
        {
            var issues = await _issueRepository.GetIssuesByFilter(
                request.IssueTypeId,
                request.IssuePriorityId,
                request.IssueStatusId);
            var users = await _userService.GetUsers();
            foreach (var issue in issues)
            {
                var tempUser = users.FirstOrDefault(u => u.Id == issue.ReporterId);
                issue.ReporterId = tempUser.InternalUserId;
                if (issue.AssigneeId != null)
                {
                    tempUser = users.FirstOrDefault(u => u.Id == issue.AssigneeId);
                    issue.AssigneeId = tempUser.InternalUserId;
                }
            }
            return _mapper.Map<List<IssuesByFilterDto>>(issues);
        }
    }
}
