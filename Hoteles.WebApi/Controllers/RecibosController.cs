using Hoteles.Aplicacion.Proceso.Recibos.Create;
using Hoteles.Aplicacion.Proceso.Recibos.Delete;
using Hoteles.Aplicacion.Proceso.Recibos.Get;
using Hoteles.Aplicacion.Proceso.Recibos.GetById;
using Hoteles.Aplicacion.Proceso.Recibos.Update;
using Hoteles.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecibosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecibosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CrearReciboCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recibo>>> GetAll()
        {
            var result = await _mediator.Send(new ObtenerRecibosQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recibo>> GetById(int id)
        {
            var result = await _mediator.Send(new ObtenerReciboPorIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarReciboCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new EliminarReciboCommand { Id = id });
            return success ? NoContent() : NotFound();
        }
    }
}
