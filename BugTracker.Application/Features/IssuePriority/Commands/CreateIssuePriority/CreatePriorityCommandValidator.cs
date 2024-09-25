using BugTracker.Application.Contracts.Persistence;
using FluentValidation;

namespace BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority
{
    public class CreatePriorityCommandValidator : AbstractValidator<CreatePriorityCommand>
    {
        private readonly IIssuePriorityRepository _issuePriorityRepository;

        public CreatePriorityCommandValidator(IIssuePriorityRepository issuePriorityRepository)
        {
            _issuePriorityRepository = issuePriorityRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must be no longer than 10 characters");

            RuleFor(p => p)
                .MustAsync(IsPriorityNameUnique)
                .WithMessage("Issue priority name already exists");
        }

        private Task<bool> IsPriorityNameUnique(CreatePriorityCommand command, CancellationToken token)
        {
            return _issuePriorityRepository.IsPriorityNameUnique(command.Name);
        }
    }
}
