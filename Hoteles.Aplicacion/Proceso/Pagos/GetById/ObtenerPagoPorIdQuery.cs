using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos.GetById
{
    public class ObtenerPagoPorIdQuery : IRequest<Dominio.Entidades.Pago>

    {

        public int Id { get; set; }

    }

}
