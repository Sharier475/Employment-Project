using EmploymentProjectTeam02.Core.Department.Command;
using EmploymentProjectTeam02.Core.Department.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<VmDepartment>> Get()
        {
            var data = await _mediator.Send(new GetAllDepartmentQuery());
            return Ok(data);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VmDepartment>>GetbyId(int id)
        {
            var data= await _mediator.Send(new GetDepartmentById(id));
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<VmDepartment>> PostAsync([FromBody] VmDepartment vmdepartment)
        {
            var data = await _mediator.Send(new CreateDepartment(vmdepartment));
            return Ok(data);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<VmDepartment>> UpdateAsync(int id,VmDepartment department)
        {
            var data = await _mediator.Send(new UpdateDepartment(id,department));
            return Ok(data);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VmDepartment>> DeleteAsync(int id)
        {
            var data = await _mediator.Send(new DeleteDepartment(id));
            return Ok(data);
        }

    }
}
