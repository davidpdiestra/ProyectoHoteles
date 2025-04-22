using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.GetById
{
    public class ObtenerCheckInPorIdQuery : IRequest<Hoteles.Dominio.Entidades.CheckIn>

    {

        public int Id { get; set; }

    }

}
