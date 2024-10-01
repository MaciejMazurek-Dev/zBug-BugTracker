using AutoMapper;
using BugTracker.Application.Features.Issue.Queries.GetAllIssues;
using BugTracker.Application.Features.Issue.Queries.GetIssueById;
using BugTracker.Domain;

namespace BugTracker.Application.MappingProfiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<Issue, IssueDto>().ReverseMap();
            CreateMap<Issue, IssueByIdDto>();
        }
    }
}
