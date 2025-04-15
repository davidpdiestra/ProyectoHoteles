using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class CheckOut
    {
        public int Id { get; set; }

        public int ReservaId { get; set; }

        public Reserva Reserva { get; set; }

        public DateTime FechaHoraSalida { get; set; }

        public float TotalConsumos { get; set; }

        public int RecepcionistaId { get; set; }

        public Factura Factura { get; set; }

    }
}
