using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.Create
{
    public class CrearCheckOutCommand : IRequest<int>
    {
        public int ReservaId { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public float TotalConsumos { get; set; }
        public int RecepcionistaId { get; set; }
    }
}
