using MediatR;
using System;

namespace Hoteles.Aplicacion.Proceso.Notificacion.Create
{
    public class CrearNotificacionCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
        public bool Enviada { get; set; }
        public int? ClienteId { get; set; }
        public int? ReservaId { get; set; }
    }
}
