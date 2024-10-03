using MediatR;

namespace BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes
{
    public class GetAllTypesQuery : IRequest<List<IssueTypesDto>>
    {
    }
}
