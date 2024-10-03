using AutoMapper;
using BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority;
using BugTracker.Application.Features.IssuePriority.Commands.UpdateIssuePriority;
using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Application.Features.IssuePriority.Queries.GetIssuePriorityById;
using BugTracker.Domain;

namespace BugTracker.Application.MappingProfiles
{
    public class IssuePriorityProfile : Profile
    {
        public IssuePriorityProfile()
        {
            CreateMap<IssuePriority, IssuePrioritiesDto>().ReverseMap();
            CreateMap<IssuePriority, IssuePriorityDto>();
            CreateMap<CreatePriorityCommand, IssuePriority>();
            CreateMap<UpdatePriorityCommand, IssuePriority>();
        }
    }
}
