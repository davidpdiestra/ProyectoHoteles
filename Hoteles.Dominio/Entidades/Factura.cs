using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class Factura
    {
        public int Id { get; set; }

        public int CheckOutId { get; set; }

        public CheckOut CheckOut { get; set; }

        public DateTime FechaEmision { get; set; }

        public float MontoTotal { get; set; }

        public string Detalle { get; set; }

    }
}
