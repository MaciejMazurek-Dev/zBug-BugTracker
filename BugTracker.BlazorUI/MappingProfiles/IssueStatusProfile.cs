using AutoMapper;
using BugTracker.BlazorUI.Models.IssueStatus;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.MappingProfiles
{
    public class IssueStatusProfile : Profile
    {
        public IssueStatusProfile()
        {
            CreateMap<IssueStatusDetailsDto, IssueStatusVM>();
            CreateMap<IssueStatusDto, IssueStatusVM>();
        }
    }
}
