using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.Update
{
    public class ActualizarCheckInCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DateTime FechaHoraIngreso { get; set; }
        public int RecepcionistaId { get; set; }
    }
}
