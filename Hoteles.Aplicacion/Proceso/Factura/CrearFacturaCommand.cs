using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura
{
    public class CrearFacturaCommand : IRequest<int>
    {
        public int CheckOutId { get; set; }
        public DateTime FechaEmision { get; set; }
        public float MontoTotal { get; set; }
        public string Detalle { get; set; }
    }
}
