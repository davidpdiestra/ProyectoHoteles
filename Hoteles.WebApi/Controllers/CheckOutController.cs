using Hoteles.Aplicacion.Proceso.CheckOut.Delete;
using Hoteles.Aplicacion.Proceso.CheckOut.Get;
using Hoteles.Aplicacion.Proceso.CheckOut.GetById;
using Hoteles.Aplicacion.Proceso.CheckOut.Update;
using Hoteles.Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hoteles.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckOutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckOutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CheckOut command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckOut>>> GetAll()
        {
            var result = await _mediator.Send(new ObtenerCheckOutsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CheckOut>> GetById(int id)
        {
            var result = await _mediator.Send(new ObtenerCheckOutPorIdQuery { Id = id });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ActualizarCheckOutCommand command)
        {
            if (id != command.Id) return BadRequest();
            var success = await _mediator.Send(command);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new EliminarCheckOutCommand { Id = id });
            return success ? NoContent() : NotFound();
        }
    }
}
