using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos.Delete
{
    public class EliminarPagoCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
