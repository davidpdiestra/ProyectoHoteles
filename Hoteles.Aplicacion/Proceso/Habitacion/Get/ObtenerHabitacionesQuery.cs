using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.Get
{
    public class ObtenerHabitacionesQuery : IRequest<IEnumerable<Hoteles.Dominio.Entidades.Habitacion>>
    {

    }

}
