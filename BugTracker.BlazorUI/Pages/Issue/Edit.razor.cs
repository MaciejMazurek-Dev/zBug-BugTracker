﻿using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Models.IssueStatus;
using BugTracker.BlazorUI.Models.IssueType;
using BugTracker.BlazorUI.Models.User;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Issue
{
    public partial class Edit
    {
        [Inject] IIssueService IssueService { get; set; }
        [Inject] IIssuePriorityService IssuePriorityService { get; set; }
        [Inject] IIssueStatusService IssueStatusService { get; set; }
        [Inject] IIssueTypeService IssueTypeService { get; set; }
        [Inject] IUserService UserService { get; set; }

        [Parameter] public int Id { get; set; }

        protected IssueDetailsVM IssueModel { get; set; } = new();
        protected List<IssuePriorityVM> IssuePriorities { get; set; } = new();
        protected List<IssueTypeVM> IssueTypes { get; set; } = new();
        protected List<IssueStatusVM> IssueStatuses { get; set; } = new();
        protected List<UserVM> UsersList { get; set; } = new();
        private readonly NavigationManager _navigation;
        public Edit(NavigationManager navigationManager)
        {
            _navigation = navigationManager;
        }
        protected async override Task OnParametersSetAsync()
        {
            var result = await IssueService.GetIssueById(Id);
            IssueModel = result.Data;
            IssuePriorities = await IssuePriorityService.GetAllIssuePriorities();
            IssueStatuses = await IssueStatusService.GetAllIssueStatuses();
            IssueTypes = await IssueTypeService.GetAllIssueTypes();
            UsersList = await UserService.GetUsers();
        }

        public async Task Update()
        {
            var result = await IssueService.UpdateIssue(IssueModel);
            if(result.Success)
            {
                _navigation.NavigateTo("/issue");
            }
            // TODO: Add error messages
        }
    }
}
