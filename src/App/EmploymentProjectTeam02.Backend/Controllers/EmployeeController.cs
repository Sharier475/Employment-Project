using EmploymentProjectTeam02.Core.Employee.Command;
using EmploymentProjectTeam02.Core.Employee.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace EmploymentProjectTeam02.Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;
    public EmployeeController (IMediator mediator)=> _mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<VmEmployee>> Get()=> Ok(await _mediator.Send(new GetAllEmployeeQuery()));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmEmployee>> GetById(int id)=> Ok(await _mediator.Send(new GetEmployeeById(id)));
    [HttpPost]
    public async Task<ActionResult<VmEmployee>> PostAsync([FromForm]VmEmployee vmEmployee)=>Ok(await _mediator.Send(new CreateEmployee(vmEmployee)));
    [HttpPut ("{id:int}")]
    public async Task<ActionResult<VmEmployee>> UpdateAsync(int id,VmEmployee employee)=> Ok(await _mediator.Send(new UpdateEmployee(id, employee)));
    [HttpDelete ("{id:int}")]
    public async Task<ActionResult<VmEmployee>> DeleteAsync(int id)=>Ok(await _mediator.Send(new DeleteEmployee(id)));
}
