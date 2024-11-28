using AutoMapper;
using BugTracker.BlazorUI.Models.Role;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleModel, RoleVM>();
        }
    }
}
