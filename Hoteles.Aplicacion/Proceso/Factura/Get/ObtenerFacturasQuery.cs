using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura.Get
{
    public class ObtenerFacturasQuery : IRequest<IEnumerable<Hoteles.Dominio.Entidades.Factura>>
    {

    }

}
