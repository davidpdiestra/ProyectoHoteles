using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.Get
{
    public class ObtenerCheckOutsQuery : IRequest<IEnumerable<Hoteles.Dominio.Entidades.CheckOut>> { }
}
