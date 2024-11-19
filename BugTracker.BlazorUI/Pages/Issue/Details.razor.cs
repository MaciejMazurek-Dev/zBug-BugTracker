using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using Microsoft.AspNetCore.Components;

namespace BugTracker.BlazorUI.Pages.Issue
{
    public partial class Details
    {
        [Inject] IIssueService IssueService { get; set; }
        [Parameter] public int Id { get; set; }

        public IssueDetailsVM IssueModel { get; set; } = new IssueDetailsVM();

        protected override async Task OnParametersSetAsync()
        {
            IssueModel = await IssueService.GetIssueById(Id);
        }
    }
}
