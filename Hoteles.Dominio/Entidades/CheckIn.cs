using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class CheckIn
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        public DateTime FechaHoraIngreso { get; set; }
        public int RecepcionistaId { get; set; }
    }
}
