using Hoteles.Aplicacion.Proceso.Reserva.Create;
using Hoteles.Aplicacion.Proceso.Reserva.Delete;
using Hoteles.Aplicacion.Proceso.Reserva.Get;
using Hoteles.Aplicacion.Proceso.Reserva.GetById;
using Hoteles.Aplicacion.Proceso.Reserva.Update;
using Hoteles.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CrearReservaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetAll()
        {
            var result = await _mediator.Send(new ObtenerReservasQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetById(int id)
        {
            var result = await _mediator.Send(new ObtenerReservaPorIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarReservaCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new EliminarReservaCommand { Id = id });
            return success ? NoContent() : NotFound();
        }
    }
}
