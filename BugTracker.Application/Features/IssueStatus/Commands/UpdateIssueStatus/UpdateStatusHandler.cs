using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueStatus.Commands.UpdateIssueStatus
{
    public class UpdateStatusHandler : IRequestHandler<UpdateStatusCommand, Unit>
    {
        private readonly IIssueStatusRepository _issueStatusRepository;
        private readonly IMapper _mapper;

        public UpdateStatusHandler(IIssueStatusRepository issueStatusRepository, IMapper mapper)
        {
            _issueStatusRepository = issueStatusRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = _mapper.Map<Domain.IssueStatus>(request);
            await _issueStatusRepository.UpdateAsync(status);
            return Unit.Value;
        }
    }
}
