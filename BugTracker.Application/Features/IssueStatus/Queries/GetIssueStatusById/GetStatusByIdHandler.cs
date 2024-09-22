using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueStatus.Queries.GetIssueStatusById
{
    public class GetStatusByIdHandler : IRequestHandler<GetStatusByIdQuery, IssueStatusDto>
    {
        private readonly IMapper _mapper;
        private readonly IIssueStatusRepository _issueStatusRepository;

        public GetStatusByIdHandler(IMapper mapper, IIssueStatusRepository issueStatusRepository)
        {
            _mapper = mapper;
            _issueStatusRepository = issueStatusRepository;
        }

        public async Task<IssueStatusDto> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var status = await _issueStatusRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<IssueStatusDto>(status);
            return result;
        }
    }
}
