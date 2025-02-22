﻿using AutoMapper;
using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Services.HttpClientBase;

namespace BugTracker.BlazorUI.MappingProfiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<IssueDto, IssueVM>();
            CreateMap<IssueDetailsDto, IssueDetailsVM>();
            CreateMap<CreateIssueVM, CreateIssueCommand>();
            CreateMap<IssueDetailsVM, UpdateIssueCommand>();
            CreateMap<IssuesByFilterDto, IssueVM>();
        }
    }
}
