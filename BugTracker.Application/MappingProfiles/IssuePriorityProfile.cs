using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Domain;

namespace BugTracker.Application.MappingProfiles
{
    public class IssuePriorityProfile : Profile
    {
        public IssuePriorityProfile()
        {
            CreateMap<IssuePriority, IssuePriorityDto>();
        }
    }
}
