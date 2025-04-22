using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos.Update
{
    public class ActualizarReciboCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int PagoId { get; set; }
        public string NumeroRecibo { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
