using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class HabitacionComodidad
    {
        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; }
        public int ComodidadId { get; set; }
        public Comodidad Comodidad { get; set; }
    }
}
