using MediatR;

namespace BugTracker.Application.Features.Issue.Queries.GetAllIssues
{
    public class GetAllIssuesQuery : IRequest<List<IssueDto>>
    {
    }
    
}
