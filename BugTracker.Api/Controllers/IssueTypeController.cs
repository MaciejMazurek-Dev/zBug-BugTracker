using BugTracker.Application.Features.IssueType.Commands.CreateIssueType;
using BugTracker.Application.Features.IssueType.Commands.DeleteIssueType;
using BugTracker.Application.Features.IssueType.Commands.UpdateIssueType;
using BugTracker.Application.Features.IssueType.Queries.GetAllIssueTypes;
using BugTracker.Application.Features.IssueType.Queries.GetIssueTypeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
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
        public async Task<ActionResult<List<IssueTypeDetailsDto>>> Get()
        {
            var types = await _mediator.Send(new GetAllTypesQuery());
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IssueTypeDto>> Get(int id)
        {
            var type = await _mediator.Send(new GetTypeByIdQuery() { Id = id });
            return Ok(type);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateTypeCommand createTypeCommand)
        {
            int typeId = await _mediator.Send(createTypeCommand);
            return CreatedAtAction(nameof(Get), new { id = typeId });
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateTypeCommand updateTypeCommand)
        {
            await _mediator.Send(updateTypeCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteTypeCommand() { Id = id });
            return NoContent();
        }
    }
}
