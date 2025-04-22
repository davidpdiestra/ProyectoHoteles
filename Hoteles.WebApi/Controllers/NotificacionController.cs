using Hoteles.Aplicacion.Proceso.Notificacion.Create;
using Hoteles.Aplicacion.Proceso.Notificacion.Delete;
using Hoteles.Aplicacion.Proceso.Notificacion.Get;
using Hoteles.Aplicacion.Proceso.Notificacion.GetById;
using Hoteles.Aplicacion.Proceso.Notificacion.Update;
using Hoteles.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificacionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CrearNotificacionCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notificacion>>> GetAll()
        {
            var result = await _mediator.Send(new ObtenerNotificacionesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notificacion>> GetById(int id)
        {
            var result = await _mediator.Send(new ObtenerNotificacionPorIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarNotificacionCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new EliminarNotificacionCommand { Id = id });
            return success ? NoContent() : NotFound();
        }
    }
}
