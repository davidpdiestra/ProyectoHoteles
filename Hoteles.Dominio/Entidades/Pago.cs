using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        public int PasarelaPagoId { get; set; }
        public PasarelaPago PasarelaPago { get; set; }
        public float Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string EstadoTransaccion { get; set; }
        public Recibo Recibo { get; set; }
    }
}
