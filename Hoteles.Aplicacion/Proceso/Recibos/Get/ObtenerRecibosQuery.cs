using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos.Get
{
    public class ObtenerRecibosQuery : IRequest<IEnumerable<Hoteles.Dominio.Entidades.Recibo>>
    {

    }

}
