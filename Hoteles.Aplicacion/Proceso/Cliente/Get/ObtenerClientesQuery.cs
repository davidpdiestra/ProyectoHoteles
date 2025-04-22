using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente.Get
{
    public class ObtenerClientesQuery : IRequest<IEnumerable<Hoteles.Dominio.Entidades.Cliente>>
    {

    }

}
