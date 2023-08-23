using EmploymentProjectTeam02.Core.Country.Command;
using EmploymentProjectTeam02.Core.Country.Query;
using EmploymentProjectTeam02.Services.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmploymentProjectTeam02.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<VmCountry>> GetById()
        {
            var data = await _mediator.Send(new GetAllCountry());
            return Ok(data);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<VmCountry>> GetById(int id)
        {
            var data = await _mediator.Send(new GetCountryById(id));
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<VmCountry>> Add([FromBody] VmCountry vmCountry)
        {
            var data = await _mediator.Send(new CreateCountry(vmCountry));
            return Ok(data);
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult<VmCountry>> Update(int id, [FromBody] VmCountry vmCountry)
        {
            var data = await _mediator.Send(new UpdateCountry(id, vmCountry)); 
            return Ok(data);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VmCountry>> Delete(int id)
        {
            var data = await _mediator.Send(new DeleteCountry(id));
            return Ok(data);
        }
    }

}

