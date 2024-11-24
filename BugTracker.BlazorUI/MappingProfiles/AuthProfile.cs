using AutoMapper;
using BugTracker.BlazorUI.Models.Authentication;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.MappingProfiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterVM, RegisterRequest>();
            CreateMap<LoginVM, LoginRequest>();
        }
    }
}
