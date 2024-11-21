using AutoMapper;
using BugTracker.Application.Features.Issue.Commands.CreateIssue;
using BugTracker.Application.Features.Issue.Commands.UpdateIssue;
using BugTracker.Application.Features.Issue.Queries.GetAllIssues;
using BugTracker.Application.Features.Issue.Queries.GetIssueById;
using BugTracker.Domain;

namespace BugTracker.Application.MappingProfiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<Issue, IssueDetailsDto>().ReverseMap();
            CreateMap<Issue, IssueDto>();
            CreateMap<CreateIssueCommand, Issue>();
            CreateMap<UpdateIssueCommand, Issue>();
        }
    }
}
