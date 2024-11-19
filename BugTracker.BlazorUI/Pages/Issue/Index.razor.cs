using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Issue
{
    public partial class Index
    {
        [Inject] IIssueService issueService { get; set; }
        List<IssueVM> Issues { get; set; } = new List<IssueVM>();

        protected async override Task OnInitializedAsync()
        {
            Issues = await issueService.GetAllIssues();
        }

        public async Task DeleteIssue(int id)
        {
            await issueService.DeleteIssue(id);
        }

        public async Task UpdateIssue(int id)
        {
            await issueService.GetIssueById(id);
        }
    }
}
