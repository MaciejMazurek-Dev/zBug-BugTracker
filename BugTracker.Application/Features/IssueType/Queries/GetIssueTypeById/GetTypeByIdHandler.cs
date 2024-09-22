using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueType.Queries.GetIssueTypeById
{
    public class GetTypeByIdHandler : IRequestHandler<GetTypeByIdQuery, IssueTypeDto>
    {
        private readonly IMapper _mapper;
        private readonly IIssueTypeRepository _issueTypeRepository;

        public GetTypeByIdHandler(IMapper mapper, IIssueTypeRepository issueTypeRepository)
        {
            _mapper = mapper;
            _issueTypeRepository = issueTypeRepository;
        }
        public async Task<IssueTypeDto> Handle(GetTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var issueType = await _issueTypeRepository.GetByIdAsync(request.Id);
            var result = _mapper.Map<IssueTypeDto>(issueType);
            return result;
        }
    }
}
