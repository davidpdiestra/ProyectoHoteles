using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public CheckIn CheckIn { get; set; }
        public CheckOut CheckOut { get; set; }
        public ICollection<Factura> Facturas { get; set; }
        public ICollection<Pago> Pagos { get; set; }

    }
}
