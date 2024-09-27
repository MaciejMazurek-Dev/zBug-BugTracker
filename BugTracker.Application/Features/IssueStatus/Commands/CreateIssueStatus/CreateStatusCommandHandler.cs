using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueStatus.Commands.CreateIssueStatus
{
    public class CreateStatusCommandHandler :IRequestHandler<CreateStatusCommand, int>
    {
        private readonly IIssueStatusRepository _issueStatusRepository;
        private readonly IMapper _mapper;

        public CreateStatusCommandHandler(IIssueStatusRepository issueStatusRepository, IMapper mapper)
        {
            _issueStatusRepository = issueStatusRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = _mapper.Map<Domain.IssueStatus>(request);
            await _issueStatusRepository.CreateAsync(status);
            return status.Id;
        }
    }
}
