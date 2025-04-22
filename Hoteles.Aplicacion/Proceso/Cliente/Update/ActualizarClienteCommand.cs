using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente.Update
{
    public class ActualizarClienteCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
