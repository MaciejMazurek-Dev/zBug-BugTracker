using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using BugTracker.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.IssueType.Commands.CreateIssueType
{
    public class CreateTypeHandler : IRequestHandler<CreateTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IIssueTypeRepository _issueTypeRepository;

        public CreateTypeHandler(IMapper mapper, IIssueTypeRepository issueTypeRepository)
        {
            _mapper = mapper;
            _issueTypeRepository = issueTypeRepository;
        }

        public async Task<int> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            var issueType = _mapper.Map<Domain.IssueType>(request);
            await _issueTypeRepository.CreateAsync(issueType);
            return issueType.Id;
        }
    }
}
