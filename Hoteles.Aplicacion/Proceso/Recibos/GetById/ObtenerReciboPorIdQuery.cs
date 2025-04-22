using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos.GetById
{
    public class ObtenerReciboPorIdQuery : IRequest<Hoteles.Dominio.Entidades.Recibo>

    {

        public int Id { get; set; }

    }

}
