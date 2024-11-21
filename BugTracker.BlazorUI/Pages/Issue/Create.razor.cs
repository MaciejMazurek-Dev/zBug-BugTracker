using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Models.IssueType;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Issue
{
    public partial class Create
    {
        [Inject] IIssuePriorityService IssuePriorityService { get; set; }
        [Inject] IIssueTypeService IssueTypeService { get; set; }
        [Inject] IIssueService IssueService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        List<IssuePriorityVM> IssuePriorities { get; set; } = new List<IssuePriorityVM>();
        List<IssueTypeVM> IssueTypes { get; set; } = new List<IssueTypeVM>();

        CreateIssueVM IssueModel { get; set; } = new CreateIssueVM();

        protected override async Task OnInitializedAsync()
        {
            IssuePriorities = await IssuePriorityService.GetAllIssuePriorities();
            IssueTypes = await IssueTypeService.GetAllIssueTypes();
        }

        public async Task Submit()
        {
            await IssueService.CreateIssue(IssueModel);
            NavigationManager.NavigateTo("/issue");
        }
    }
}
