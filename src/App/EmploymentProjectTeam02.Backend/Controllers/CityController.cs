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
    public CityController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<VmCity>> Get()
    {
        var data = await _mediator.Send(new GetAllCityQuery());
        return Ok(data);
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmCity>> Get(int id)
    {
        var data = await _mediator.Send(new GetCityById(id));
        return Ok(data);
    }
    [HttpPost]
    public async Task<ActionResult<VmCity>> PostAsync([FromBody] VmCity vmCity)
    {
        var data = await _mediator.Send(new CreateCity(vmCity));
        return Ok(data);

    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<VmCity>> PutAsync(int id, [FromBody] VmCity vmCity)
    {
        var data = await _mediator.Send(new UpdateCity(id, vmCity));
        return Ok(data);
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VmCity>> DeleteAsync(int id)
    {
        var data = await _mediator.Send(new DeleteCity(id));
        return Ok(data);
    }
}
