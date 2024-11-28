using BugTracker.Application.Features.IssueType.Commands.CreateIssueType;
using BugTracker.Application.Features.IssueType.Commands.DeleteIssueType;
using BugTracker.Application.Features.IssueType.Commands.UpdateIssueType;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;
using BugTracker.Application.Features.IssueType.Queries.GetIssueTypeById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IssueTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<IssueTypeDetailsDto>>> Get()
        {
            var types = await _mediator.Send(new GetAllTypesQuery());
            return Ok(types);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IssueTypeDto>> Get(int id)
        {
            var type = await _mediator.Send(new GetTypeByIdQuery() { Id = id });
            return Ok(type);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(CreateTypeCommand createTypeCommand)
        {
            int typeId = await _mediator.Send(createTypeCommand);
            return CreatedAtAction(nameof(Get), new { id = typeId });
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Put(UpdateTypeCommand updateTypeCommand)
        {
            await _mediator.Send(updateTypeCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTypeCommand() { Id = id });
            return NoContent();
        }
    }
}
