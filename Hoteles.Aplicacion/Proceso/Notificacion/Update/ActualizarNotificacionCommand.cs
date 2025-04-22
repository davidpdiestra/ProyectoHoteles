using MediatR;

namespace Hoteles.Aplicacion.Proceso.Notificacion.Update
{
    public class ActualizarNotificacionCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
        public bool Enviada { get; set; }
        public int? ClienteId { get; set; }
        public int? ReservaId { get; set; }
    }
}
