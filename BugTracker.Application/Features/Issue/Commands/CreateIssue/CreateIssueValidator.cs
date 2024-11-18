using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.Features.Issue.Commands.CreateIssue
{
    public class CreateIssueValidator : AbstractValidator<CreateIssueCommand>
    {
        public CreateIssueValidator()
        {
            RuleFor(issue => issue.IssuePriorityId)
                .NotEmpty()
                .NotNull();
            RuleFor(issue => issue.Summary)
                .NotEmpty()
                .NotNull();
            RuleFor(issue => issue.IssueTypeId)
                .NotEmpty()
                .NotNull();
        }
    }
}
