using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Notificacion
{
    public class CrearNotificacionCommand : IRequest<int>

    {

        public string Titulo { get; set; }

        public string Mensaje { get; set; }

        public DateTime FechaEnvio { get; set; }

        public int? ClienteId { get; set; }

        public int? ReservaId { get; set; }

    }

}
