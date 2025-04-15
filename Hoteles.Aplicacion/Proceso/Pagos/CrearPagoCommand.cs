using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos
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
