using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion
{
    public class CrearHabitacionCommand : IRequest<int>
    {
        public string Numero { get; set; }
        public int TipoHabitacionId { get; set; }
        public float Precio { get; set; }
        public bool Disponible { get; set; } = true;
        public string Descripcion { get; set; }
    }
}
