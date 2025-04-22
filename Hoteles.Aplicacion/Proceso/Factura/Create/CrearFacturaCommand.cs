using MediatR;
using System;

namespace Hoteles.Aplicacion.Proceso.Factura.Create
{
    public class CrearFacturaCommand : IRequest<int>
    {
        public int CheckOutId { get; set; }
        public DateTime FechaEmision { get; set; }
        public float MontoTotal { get; set; }
        public string Detalle { get; set; }
    }
}
