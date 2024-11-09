using BugTracker.Application.Features.IssuePriority.Commands.CreateIssuePriority;
using BugTracker.Application.Features.IssuePriority.Commands.DeleteIssuePriority;
using BugTracker.Application.Features.IssuePriority.Commands.UpdateIssuePriority;
using BugTracker.Application.Features.IssuePriority.Queries.GetAllIssuePriorities;
using BugTracker.Application.Features.IssuePriority.Queries.GetIssuePriorityById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuePriorityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssuePriorityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<IssuePriorityDto>>> Get()
        {
            var priorities =  await _mediator.Send(new GetAllPrioritiesQuery());
            return Ok(priorities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IssuePriorityDetailsDto>> Get(int id)
        {
            var priority = await _mediator.Send(new GetPriorityByIdQuery() { Id = id});
            return Ok(priority);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreatePriorityCommand createPriorityCommand)
        {
            int priorityId = await _mediator.Send(createPriorityCommand);
            return CreatedAtAction(nameof(Get), new { id = priorityId });
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdatePriorityCommand updatePriorityCommand)
        {
            await _mediator.Send(updatePriorityCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletePriorityCommand() { Id = id });
            return NoContent();
        }
    }
}
