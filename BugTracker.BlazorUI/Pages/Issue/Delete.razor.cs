using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Issue
{
    public partial class Delete
    {
        [Inject] IIssueService IssueService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Parameter] public int Id { get; set; }
        public IssueDetailsVM IssueModel { get; set; } = new();

        protected async override Task OnInitializedAsync()
        {
            var result = await IssueService.GetIssueById(Id);
            IssueModel = result.Data;
        }
        public async Task DeleteIssue()
        {
            await IssueService.DeleteIssue(Id);
        }

        
        
    }
}
