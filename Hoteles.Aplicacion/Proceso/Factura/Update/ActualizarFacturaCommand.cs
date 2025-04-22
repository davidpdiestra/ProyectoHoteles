using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura.Update
{
    public class ActualizarFacturaCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int CheckOutId { get; set; }
        public DateTime FechaEmision { get; set; }
        public float MontoTotal { get; set; }
        public string Detalle { get; set; }
    }
}
