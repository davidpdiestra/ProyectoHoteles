using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class ImagenHabitacion
    {
        public int Id { get; set; }
        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; }
        public string Url { get; set; }
        public string Descripcion { get; set; }
    }
}
