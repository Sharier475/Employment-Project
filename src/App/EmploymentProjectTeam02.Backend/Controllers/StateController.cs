using EmploymentProjectTeam02.Core.State.Command;
using EmploymentProjectTeam02.Core.State.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IMediator _mediator;
    public StateController(IMediator mediator)=> _mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<VmState>> Get()=> Ok(await _mediator.Send(new GetAllStateQuery()));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmState>> Get(int id)=>Ok(await _mediator.Send(new GetStateById(id)));
    [HttpPost]
    public async Task<ActionResult<VmState>> PostAsync([FromBody] VmState vmState)=> Ok(await _mediator.Send(new CreateState(vmState)));
    [HttpPut("{id:int}")]
    public async Task<ActionResult<VmState>> PutAsync(int id, [FromBody] VmState vmState)=> Ok(await _mediator.Send(new UpdateState(id, vmState)));
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VmState>> DeleteAsync(int id)=> Ok(await _mediator.Send(new DeleteState(id)));
    
}

