using BugTracker.Application.Features.IssueStatus.Commands.CreateIssueStatus;
using BugTracker.Application.Features.IssueStatus.Commands.DeleteIssueStatus;
using BugTracker.Application.Features.IssueStatus.Commands.UpdateIssueStatus;
using BugTracker.Application.Features.IssueStatus.Queries.GetAllIssueStatuses;
using BugTracker.Application.Features.IssueStatus.Queries.GetIssueStatusById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueStatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<IssueStatusDetailsDto>>> Get()
        {
            var statuses = await _mediator.Send(new GetAllStatusesQuery());
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IssueStatusDetailsDto>> Get(int id)
        {
            var status = await _mediator.Send(new GetStatusByIdQuery() { Id = id });
            return Ok(status);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateStatusCommand createStatusCommand)
        {
            int statusId = await _mediator.Send(createStatusCommand);
            return CreatedAtAction(nameof(Get), new { id = statusId });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateStatusCommand updateStatusCommand)
        {
            await _mediator.Send(updateStatusCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteStatusCommand() { Id = id });
            return NoContent();
        }
    }
}

