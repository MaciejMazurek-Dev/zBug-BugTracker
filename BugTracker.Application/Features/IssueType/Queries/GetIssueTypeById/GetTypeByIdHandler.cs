using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.IssueType.Queries.GetIssueTypeById
{
    public class GetTypeByIdHandler : IRequestHandler<GetTypeByIdQuery, IssueTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IIssueTypeRepository _issueTypeRepository;

        public GetTypeByIdHandler(IMapper mapper, IIssueTypeRepository issueTypeRepository)
        {
            _mapper = mapper;
            _issueTypeRepository = issueTypeRepository;
        }
        public async Task<IssueTypeDetailsDto> Handle(GetTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var issueType = await _issueTypeRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<IssueTypeDetailsDto>(issueType);
            return result;
        }
    }
}
