using EmploymentProjectTeam02.Core.State.Command;
using EmploymentProjectTeam02.Core.State.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<VmState>> Get()
        {
            var data = await _mediator.Send(new GetAllStateQuery());
            return Ok(data);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VmState>> Get(int id)
        {
            var data = await _mediator.Send(new GetStateById(id));
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<VmState>> PostAsync([FromBody] VmState vmState)
        {
            var data = await _mediator.Send(new CreateState(vmState));
            return Ok(data);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<VmState>> PutAsync(int id, [FromBody] VmState vmState)
        {
            var data = await _mediator.Send(new UpdateState(id, vmState));
            return Ok(data);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VmState>> DeleteAsync(int id)
        {
            var data = await _mediator.Send(new DeleteState(id));
            return Ok(data);
        }
    }
}

