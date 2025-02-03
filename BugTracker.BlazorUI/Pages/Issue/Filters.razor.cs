using BugTracker.BlazorUI.Contracts;
using BugTracker.BlazorUI.Models.Issue;
using BugTracker.BlazorUI.Models.IssuePriority;
using BugTracker.BlazorUI.Models.IssueStatus;
using BugTracker.BlazorUI.Models.IssueType;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace BugTracker.BlazorUI.Pages.Issue
{
    public partial class Filters
    {
        [Inject] IIssuePriorityService IssuePriorityService { get; set; }
        [Inject] IIssueTypeService IssueTypeService { get; set; }
        [Inject] IIssueStatusService IssueStatusService { get; set; }
        [Inject] IIssueService IssueService { get; set; }
        List<IssuePriorityVM> IssuePriorities { get; set; } = new List<IssuePriorityVM>();
        List<IssueTypeVM> IssueTypes { get; set; } = new List<IssueTypeVM>();
        List<IssueStatusVM> IssueStatuses { get; set; } = new List<IssueStatusVM>();

        QuickGrid<IssueVM>? grid;
        GridItemsProvider<IssueVM>? issuesProvider;
        protected int? selectedStatusId = null;
        protected int? selectedPriorityId = null;
        protected int? selectedTypeId = null;

        protected async override Task OnInitializedAsync()
        {
            IssuePriorities = await IssuePriorityService.GetAllIssuePriorities();
            IssueTypes = await IssueTypeService.GetAllIssueTypes();
            IssueStatuses = await IssueStatusService.GetAllIssueStatuses();

            issuesProvider = async req =>
            {
                var response = await GetIssues(req);
                return GridItemsProviderResult.From(response, 0);

            };
        }
        private async Task<List<IssueVM>> GetIssues(GridItemsProviderRequest<IssueVM> req)
        {
            var result = await IssueService.GetIssuesByFilter(selectedTypeId, selectedStatusId, selectedPriorityId);
            return result.Data;
        }
        protected Task FilterChangedAsync()
        {
            return grid.RefreshDataAsync();
        }
    }
}
