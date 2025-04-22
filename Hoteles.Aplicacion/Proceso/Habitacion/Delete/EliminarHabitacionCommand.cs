using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.Delete
{
    public class EliminarHabitacionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
