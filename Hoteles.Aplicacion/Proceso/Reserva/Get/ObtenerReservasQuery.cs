using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva.Get
{
    public class ObtenerReservasQuery : IRequest<IEnumerable<Hoteles.Dominio.Entidades.Reserva>>
    {

    }

}
