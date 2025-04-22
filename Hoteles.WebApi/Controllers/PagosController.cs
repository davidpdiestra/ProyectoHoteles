using Hoteles.Aplicacion.Proceso.Pagos.Create;
using Hoteles.Aplicacion.Proceso.Pagos.Delete;
using Hoteles.Aplicacion.Proceso.Pagos.Get;
using Hoteles.Aplicacion.Proceso.Pagos.GetById;
using Hoteles.Aplicacion.Proceso.Pagos.Update;
using Hoteles.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PagosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CrearPagoCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pago>>> GetAll()
        {
            var result = await _mediator.Send(new ObtenerPagosQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pago>> GetById(int id)
        {
            var result = await _mediator.Send(new ObtenerPagoPorIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarPagoCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new EliminarPagoCommand { Id = id });
            return success ? NoContent() : NotFound();
        }
    }
}
