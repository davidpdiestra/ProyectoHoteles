using Hoteles.Aplicacion.Proceso.CheckIn.Create;
using Hoteles.Aplicacion.Proceso.CheckIn.Delete;
using Hoteles.Aplicacion.Proceso.CheckIn.Get;
using Hoteles.Aplicacion.Proceso.CheckIn.GetById;
using Hoteles.Aplicacion.Proceso.CheckIn.Update;
using Hoteles.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckInController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CrearCheckInCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckIn>>> GetAll()
        {
            var result = await _mediator.Send(new ObtenerCheckInsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CheckIn>> GetById(int id)
        {
            var result = await _mediator.Send(new ObtenerCheckInPorIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarCheckInCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new EliminarCheckInCommand { Id = id });
            return success ? NoContent() : NotFound();
        }
    }
}
