using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issue.Commands.CreateIssue
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IIssueRepository _issueRepository;

        public CreateIssueCommandHandler(IMapper mapper, IIssueRepository issueRepository)
        {
            _mapper = mapper;
            _issueRepository = issueRepository;
        }

        public async Task<int> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {

            
        }
    }
}
