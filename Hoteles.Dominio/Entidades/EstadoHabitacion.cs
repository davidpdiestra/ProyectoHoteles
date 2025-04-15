using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class EstadoHabitacion
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime ultimaActualizacion { get; set; }
    }
}
