using AutoMapper;
using BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority;
using BugTracker.Application.Features.IssuePriority.Commands.UpdateIssuePriority;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;
using BugTracker.Application.Features.IssueType.Queries.GetIssueTypeById;
using BugTracker.Domain;

namespace BugTracker.Application.MappingProfiles
{
    public class IssueTypeProfile : Profile
    {
        public IssueTypeProfile()
        {
            CreateMap<IssueType, IssueTypesDto>().ReverseMap();
            CreateMap<IssueType, IssueTypeDto>();
            CreateMap<CreatePriorityCommand, IssueType>();
            CreateMap<UpdatePriorityCommand, IssueType>();
        }
    }
}
