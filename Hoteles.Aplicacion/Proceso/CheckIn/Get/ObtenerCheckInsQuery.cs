using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.Get
{
    public class ObtenerCheckInsQuery : IRequest<IEnumerable<Hoteles.Dominio.Entidades.CheckIn>>
    {

    }

}
