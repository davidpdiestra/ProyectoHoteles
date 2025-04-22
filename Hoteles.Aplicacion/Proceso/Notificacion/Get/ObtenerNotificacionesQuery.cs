using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Notificacion.Get
{
    public class ObtenerNotificacionesQuery : IRequest<IEnumerable<Hoteles.Dominio.Entidades.Notificacion>>
    {

    }

}
