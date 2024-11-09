using BugTracker.Application.Features.Issue.Queries.GetAllIssues;
using BugTracker.Application.Features.Issue.Queries.GetIssueById;
using BugTracker.Application.Features.Issue.Commands.CreateIssue;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Application.Features.Issue.Commands.UpdateIssue;
using Microsoft.AspNetCore.Http.HttpResults;
using BugTracker.Application.Features.Issue.Commands.DeleteIssue;

namespace BugTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<IssueDto>>> Get()
        {
            var issues =  await _mediator.Send(new GetAllIssuesQuery());
            return Ok(issues);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IssueDetailsDto>> Get(int id)
        {
            var issue = await _mediator.Send(new GetIssueByIdQuery { Id = id });
            return Ok(issue);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateIssueCommand createIssueCommand)
        {
            var issueId = await _mediator.Send(createIssueCommand);
            return CreatedAtAction(nameof(Get), new {id = issueId});
        }
        
        [HttpPut]
        public async Task<ActionResult> Put(UpdateIssueCommand updateIssueCommand)
        {
            await _mediator.Send(updateIssueCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteIssueCommand { Id = id });
            return NoContent();
        }
    }
}
