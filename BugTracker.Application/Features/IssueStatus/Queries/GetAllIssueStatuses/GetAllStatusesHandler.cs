using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses
{
    public class GetAllStatusesHandler : IRequestHandler<GetAllStatusesQuery, List<IssueStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssueStatusRepository _issueStatusRepository;

        public GetAllStatusesHandler(IMapper mapper, IIssueStatusRepository issueStatusRepository)
        {
            _mapper = mapper;
            _issueStatusRepository = issueStatusRepository;
        }
        public async Task<List<IssueStatusDto>> Handle(GetAllStatusesQuery request, CancellationToken cancellationToken)
        {
            var statuses = await _issueStatusRepository.GetAllAsync();
            var result = _mapper.Map<List<IssueStatusDto>>(statuses);
            return result;
        }
    }
}
