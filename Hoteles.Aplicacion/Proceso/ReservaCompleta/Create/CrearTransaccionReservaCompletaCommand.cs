using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Proceso.CheckIn.Create;
using Hoteles.Aplicacion.Proceso.Factura.Create;
using Hoteles.Aplicacion.Proceso.Pagos.Create;
using Hoteles.Aplicacion.Proceso.Reserva.Create;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.ReservaCompleta.Create
{
    public class CrearTransaccionReservaCompletaCommand : IRequest<int>
    {
        public CrearReservaCommand Reserva { get; set; }
        public CrearCheckInCommand CheckIn { get; set; }
        public CrearPagoCommand Pago { get; set; }
        public CrearFacturaCommand Factura { get; set; }
    }
}
