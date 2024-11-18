using AutoMapper;
using BugTracker.BlazorUI.Models.IssueType;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.MappingProfiles
{
    public class IssueTypeProfile : Profile
    {
        public IssueTypeProfile()
        {
            CreateMap<IssueTypeDetailsDto, IssueTypeVM>();
            CreateMap<IssueTypeDto, IssueTypeVM>();
        }
    }
}
