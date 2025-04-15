using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Proceso.CheckIn;
using Hoteles.Aplicacion.Proceso.Factura;
using Hoteles.Aplicacion.Proceso.Pagos;
using Hoteles.Aplicacion.Proceso.Reserva;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.ReservaCompleta
{
    public class CrearTransaccionReservaCompletaCommand : IRequest<int>
    {
        public CrearReservaCommand Reserva { get; set; }
        public CheckInCommand CheckIn { get; set; }
        public CrearPagoCommand Pago { get; set; }
        public CrearFacturaCommand Factura { get; set; }
    }
}
