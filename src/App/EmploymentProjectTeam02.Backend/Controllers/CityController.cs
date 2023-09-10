using EmploymentProjectTeam02.Core.City.Command;
using EmploymentProjectTeam02.Core.City.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly IMediator _mediator;
    public CityController(IMediator mediator)=>_mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<VmCity>> Get()=> Ok(await _mediator.Send(new GetAllCityQuery()));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmCity>> Get(int id)=> Ok(await _mediator.Send(new GetCityById(id)));
    [HttpPost]
    public async Task<ActionResult<VmCity>> PostAsync([FromBody] VmCity vmCity)=> Ok(await _mediator.Send(new CreateCity(vmCity)));
    [HttpPut("{id:int}")]
    public async Task<ActionResult<VmCity>> PutAsync(int id, [FromBody] VmCity vmCity)=> Ok(await _mediator.Send(new UpdateCity(id, vmCity)));
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VmCity>> DeleteAsync(int id)=> Ok(await _mediator.Send(new DeleteCity(id)));
    
}
