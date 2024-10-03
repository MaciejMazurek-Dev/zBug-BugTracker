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

        // GET: api/<IssuePriorityController>
        [HttpGet]
        public async Task<List<IssuePrioritiesDto>> Get()
        {
            return await _mediator.Send(new GetAllPrioritiesQuery());
        }

        // GET api/<IssuePriorityController>/5
        [HttpGet("{id}")]
        public async Task<IssuePriorityDto> Get(int id)
        {
            return await _mediator.Send(new GetPriorityByIdQuery() { Id = id});
        }

        // POST api/<IssuePriorityController>
        [HttpPost]
        public async Task<int> Post([FromBody] string name)
        {
            return await _mediator.Send(new CreatePriorityCommand() { Name = name });
        }

        // PUT api/<IssuePriorityController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] string name)
        {
            await _mediator.Send(new UpdatePriorityCommand() { Id = id, Name = name });
        }

        // DELETE api/<IssuePriorityController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _mediator.Send(new DeletePriorityCommand() { Id = id });
        }
    }
}
