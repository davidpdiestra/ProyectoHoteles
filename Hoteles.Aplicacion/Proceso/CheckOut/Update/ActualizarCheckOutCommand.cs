using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.Update
{
    public class ActualizarCheckOutCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public float TotalConsumos { get; set; }
        public int RecepcionistaId { get; set; }
    }
}
