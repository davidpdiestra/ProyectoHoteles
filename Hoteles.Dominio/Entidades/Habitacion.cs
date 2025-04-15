using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Dominio.Entidades
{
    public class Habitacion
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public int TipoHabitacionId { get; set; }

        public TipoHabitacion TipoHabitacion { get; set; }

        public float Precio { get; set; }

        public bool Disponible { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
        public ICollection<HabitacionComodidad> HabitacionComodidades { get; set; }
        public ICollection<ImagenHabitacion> Imagenes { get; set; }

    }
}
