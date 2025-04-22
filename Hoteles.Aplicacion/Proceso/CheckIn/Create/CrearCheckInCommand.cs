using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.Create
{
    public class CrearCheckInCommand : IRequest<int>
    {
        public int ReservaId { get; set; }
        public DateTime FechaHoraIngreso { get; set; }
        public int RecepcionistaId { get; set; }
    }
}
