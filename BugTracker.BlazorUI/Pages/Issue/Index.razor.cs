using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace BugTracker.BlazorUI.Pages.Issue
{
    public partial class Index
    {
        [Inject] IIssueService issueService { get; set; }
        IQueryable<IssueVM> Issues { get; set; }
        
        protected async override Task OnInitializedAsync()
        {
            var result = await issueService.GetAllIssues();
            Issues = result.Data.AsQueryable();
        }
    }
}
