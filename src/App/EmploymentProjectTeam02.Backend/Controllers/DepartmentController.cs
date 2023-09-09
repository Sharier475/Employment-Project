using EmploymentProjectTeam02.Core.Department.Command;
using EmploymentProjectTeam02.Core.Department.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IMediator _mediator;
    public DepartmentController(IMediator mediator)=> _mediator = mediator;
    [HttpGet]
    public async Task<ActionResult<VmDepartment>> Get()=> Ok(await _mediator.Send(new GetAllDepartmentQuery()));
    [HttpGet("{id:int}")]
    public async Task<ActionResult<VmDepartment>>GetbyId(int id)=> Ok(await _mediator.Send(new GetDepartmentById(id)));
    [HttpPost]
    public async Task<ActionResult<VmDepartment>> PostAsync([FromBody] VmDepartment vmdepartment)=> Ok(await _mediator.Send(new CreateDepartment(vmdepartment)));
    [HttpPut("{id:int}")]
    public async Task<ActionResult<VmDepartment>> UpdateAsync(int id,VmDepartment department)=> Ok(await _mediator.Send(new UpdateDepartment(id, department)));
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<VmDepartment>> DeleteAsync(int id)=> Ok(await _mediator.Send(new DeleteDepartment(id)));
}
