using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class Recibo
    {
        public int Id { get; set; }
        public int PagoId { get; set; }
        public Pago Pago { get; set; }
        public string NumeroRecibo { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
