using MediatR;
using System;

namespace Hoteles.Aplicacion.Proceso.Pagos.Create
{
    public class CrearPagoCommand : IRequest<int>
    {
        public int ReservaId { get; set; }
        public int PasarelaPagoId { get; set; }
        public float Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string EstadoTransaccion { get; set; }
    }
}
