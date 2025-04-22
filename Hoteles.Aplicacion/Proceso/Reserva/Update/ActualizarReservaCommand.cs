using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva.Update
{
    public class ActualizarReservaCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int HabitacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
    }
}
