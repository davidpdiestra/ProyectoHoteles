using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva.GetById
{
    public class ObtenerReservaPorIdQuery : IRequest<Hoteles.Dominio.Entidades.Reserva>

    {

        public int Id { get; set; }

    }

}
