using AutoMapper;
using BugTracker.Application.Contracts.Persistence;
using BugTracker.Application.Exceptions;
using MediatR;

namespace BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority
{
    public class CreatePriorityCommandHandler : IRequestHandler<CreatePriorityCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IIssuePriorityRepository _issuePriorityRepository;

        public CreatePriorityCommandHandler(IMapper mapper, IIssuePriorityRepository issuePriorityRepository)
        {
            _mapper = mapper;
            _issuePriorityRepository = issuePriorityRepository;
        }


        public async Task<int> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePriorityCommandValidator(_issuePriorityRepository);
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid IssuePriority", validationResult);
            }

            var issuePriority = _mapper.Map<Domain.IssuePriority>(request);
            await _issuePriorityRepository.CreateAsync(issuePriority);
            return issuePriority.Id;
        }
    }
}
