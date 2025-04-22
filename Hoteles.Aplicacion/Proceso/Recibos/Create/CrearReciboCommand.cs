using MediatR;
using System;

namespace Hoteles.Aplicacion.Proceso.Recibos.Create
{
    public class CrearReciboCommand : IRequest<int>
    {
        public int PagoId { get; set; }
        public string NumeroRecibo { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
