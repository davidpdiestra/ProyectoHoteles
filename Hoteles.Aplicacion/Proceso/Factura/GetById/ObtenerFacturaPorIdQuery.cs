using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura.GetById
{
    public class ObtenerFacturaPorIdQuery : IRequest<Hoteles.Dominio.Entidades.Factura>

    {

        public int Id { get; set; }

    }

}
