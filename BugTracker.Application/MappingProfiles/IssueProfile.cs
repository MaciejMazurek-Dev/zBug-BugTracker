using AutoMapper;
using BugTracker.Application.Features.Issue.Queries.GetAllIssues;
using BugTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Application.MappingProfiles
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<IssueDto, Issue>().ReverseMap();
        }
    }
}
