using Hoteles.Aplicacion.Proceso.Factura.Create;
using Hoteles.Aplicacion.Proceso.Factura.Delete;
using Hoteles.Aplicacion.Proceso.Factura.Get;
using Hoteles.Aplicacion.Proceso.Factura.GetById;
using Hoteles.Aplicacion.Proceso.Factura.Update;
using Hoteles.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacturaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CrearFacturaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetAll()
        {
            var result = await _mediator.Send(new ObtenerFacturasQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetById(int id)
        {
            var result = await _mediator.Send(new ObtenerFacturaPorIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarFacturaCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new EliminarFacturaCommand { Id = id });
            return success ? NoContent() : NotFound();
        }
    }
}
