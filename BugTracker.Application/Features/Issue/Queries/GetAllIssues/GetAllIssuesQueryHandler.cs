using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issue.Queries.GetAllIssues
{
    public class GetAllIssuesQueryHandler :
        IRequestHandler<GetAllIssuesQuery, List<IssueDto>>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;

        public GetAllIssuesQueryHandler(IMapper mapper, IIssueRepository issueRepository)
        {
            this._mapper = mapper;
            this._issueRepository = issueRepository;
        }
        public async Task<List<IssueDto>> Handle(GetAllIssuesQuery request, CancellationToken cancellationToken)
        {
            var issues = await _issueRepository.GetAllAsync();

            var data = _mapper.Map<List<IssueDto>>(issues);

            return data;
        }
    }
}
