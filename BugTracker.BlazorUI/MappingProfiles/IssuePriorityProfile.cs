using AutoMapper;
using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.MappingProfiles
{
    public class IssuePriorityProfile : Profile
    {
        public IssuePriorityProfile()
        {
            CreateMap<IssuePriorityDetailsDto, IssuePriorityVM>();
            CreateMap<IssuePriorityDto, IssuePriorityVM>();
        }
    }
}
