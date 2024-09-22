using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueType.Commands.UpdateIssueType
{
    public class UpdateTypeHandler : IRequestHandler<UpdateTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IIssueTypeRepository _issueTypeRepository;

        public UpdateTypeHandler(IMapper mapper, IIssueTypeRepository issueTypeRepository)
        {
            _mapper = mapper;
            _issueTypeRepository = issueTypeRepository;
        }
        public async Task<Unit> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var issueType = _mapper.Map<Domain.IssueType>(request);
            await _issueTypeRepository.UpdateAsync(issueType);
            return Unit.Value;
        }
    }
}
