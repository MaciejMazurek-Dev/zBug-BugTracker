using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;

namespace BugTracker.Application.Features.IssueStatus.Queries.GetIssueStatusById
{
    public class GetStatusByIdHandler : IRequestHandler<GetStatusByIdQuery, IssueStatusDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IIssueStatusRepository _issueStatusRepository;

        public GetStatusByIdHandler(IMapper mapper, IIssueStatusRepository issueStatusRepository)
        {
            _mapper = mapper;
            _issueStatusRepository = issueStatusRepository;
        }

        public async Task<IssueStatusDetailsDto> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var status = await _issueStatusRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<IssueStatusDetailsDto>(status);
            return result;
        }
    }
}
