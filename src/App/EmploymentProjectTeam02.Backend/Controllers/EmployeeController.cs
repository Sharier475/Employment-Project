using EmploymentProjectTeam02.Core.Employee.Command;
using EmploymentProjectTeam02.Core.Employee.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

        public async Task<ActionResult<VmEmployee>> Get()
        {
            var data = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(data);
        }


        [HttpGet("{id:int}")]

        public async Task<ActionResult<VmEmployee>> GetById(int id)
        {
            var data = await _mediator.Send(new GetEmployeeById(id));
            return Ok(data);
        }
        [HttpPost]

        public async Task<ActionResult<VmEmployee>> PostAsync([FromBody]VmEmployee vmEmployee)
        {
            var data = await _mediator.Send(new CreateEmployee(vmEmployee));
            return Ok(data);
        }
        [HttpPut ("{id:int}")]

        public async Task<ActionResult<VmEmployee>> UpdateAsync(int id,VmEmployee employee)
        {
            var data = await _mediator.Send(new UpdateEmployee(id, employee));
            return Ok(data);
        }

        [HttpDelete ("{id:int}")]
        public async Task<ActionResult<VmEmployee>> DeleteAsync(int id)
        {
            var data = await _mediator.Send(new DeleteEmployee(id));
            return Ok(data);
        }

    }
}
