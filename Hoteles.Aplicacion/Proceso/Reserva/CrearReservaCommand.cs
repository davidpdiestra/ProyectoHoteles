using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva
{
    public class CrearReservaCommand : IRequest<int>

    {

        public int ClienteId { get; set; }

        public int HabitacionId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Estado { get; set; } = "Pendiente";

    }

}
