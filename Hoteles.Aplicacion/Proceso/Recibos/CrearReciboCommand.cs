using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos
{
    public class CrearReciboCommand : IRequest<int>
    {
        public int PagoId { get; set; }
        public string NumeroRecibo { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
