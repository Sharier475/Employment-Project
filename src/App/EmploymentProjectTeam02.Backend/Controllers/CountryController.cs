using EmploymentProjectTeam02.Core.Country.Command;
using EmploymentProjectTeam02.Core.Country.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;
    public CountryController(IMediator mediator)=> _mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<VmCountry>> GetById()=> Ok(await _mediator.Send(new GetAllCountry()));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmCountry>> GetById(int id)=> Ok(await _mediator.Send(new GetCountryById(id)));
    [HttpPost]
    public async Task<ActionResult<VmCountry>> Add([FromBody] VmCountry vmCountry)=> Ok(await _mediator.Send(new CreateCountry(vmCountry)));
    [HttpPut("{id:int}")]
    public async Task<ActionResult<VmCountry>> Update(int id, [FromBody] VmCountry vmCountry)=> Ok(await _mediator.Send(new UpdateCountry(id, vmCountry)));
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VmCountry>> Delete(int id)=> Ok(await _mediator.Send(new DeleteCountry(id)));
    
}

