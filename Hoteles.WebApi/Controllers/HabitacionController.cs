using Hoteles.Aplicacion.Proceso.Habitacion.Create;
using Hoteles.Aplicacion.Proceso.Habitacion.Delete;
using Hoteles.Aplicacion.Proceso.Habitacion.Get;
using Hoteles.Aplicacion.Proceso.Habitacion.GetById;
using Hoteles.Aplicacion.Proceso.Habitacion.Update;
using Hoteles.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitacionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HabitacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CrearHabitacionCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetAll()
        {
            var result = await _mediator.Send(new ObtenerHabitacionesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Habitacion>> GetById(int id)
        {
            var result = await _mediator.Send(new ObtenerHabitacionPorIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarHabitacionCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new EliminarHabitacionCommand { Id = id });
            return success ? NoContent() : NotFound();
        }
    }
}
