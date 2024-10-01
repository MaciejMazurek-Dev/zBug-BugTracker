using AutoMapper;
using BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority;
using BugTracker.Application.Features.IssuePriority.Commands.UpdateIssuePriority;
using BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses;
using BugTracker.Application.Features.IssueStatus.Queries.GetIssueStatusById;
using BugTracker.Domain;

namespace BugTracker.Application.MappingProfiles
{
    public class IssueStatusProfile : Profile
    {
        public IssueStatusProfile()
        {
            CreateMap<IssueStatus, IssueStatusDto>().ReverseMap();
            CreateMap<IssueStatus, IssueStatusByIdDto>();
            CreateMap<CreatePriorityCommand, IssueStatus>();
            CreateMap<UpdatePriorityCommand, IssueStatus>();
        }
    }
}
