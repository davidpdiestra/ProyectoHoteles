using MediatR;
using System;

namespace Hoteles.Aplicacion.Proceso.Reserva.Create
{
    public class CrearReservaCommand : IRequest<int>
    {
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
    }
}
