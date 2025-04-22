using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva.Delete
{
    public class EliminarReservaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
