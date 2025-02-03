using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetIssuesByFilter
{
    public class GetIssuesByFilterHandler : IRequestHandler<GetIssuesByFilterQuery, List<IssuesByFilterDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;
        public GetIssuesByFilterHandler(IMapper mapper, IIssueRepository issueRepository)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;
        }

        public async Task<List<IssuesByFilterDto>> Handle(GetIssuesByFilterQuery request, CancellationToken cancellationToken)
        {
            var issues = await _issueRepository.GetIssuesByFilter(
                request.IssueTypeId,
                request.IssuePriorityId,
                request.IssueStatusId);
            return _mapper.Map<List<IssuesByFilterDto>>(issues);
        }
    }
}
