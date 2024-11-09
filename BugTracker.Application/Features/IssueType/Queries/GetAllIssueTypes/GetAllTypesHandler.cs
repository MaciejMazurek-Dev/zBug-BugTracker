using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, List<IssueTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssueTypeRepository _issueTypeRepository;

        public GetAllTypesHandler(IMapper mapper, IIssueTypeRepository issueTypeRepository)
        {
            _mapper = mapper;
            _issueTypeRepository = issueTypeRepository;
        }

        public async Task<List<IssueTypeDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var issueType = _issueTypeRepository.GetAllAsync();
            var result = _mapper.Map<List<IssueTypeDto>>(issueType);
            return result;
        }
    }
}
