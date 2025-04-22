using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente.GetById
{
    public class ObtenerClientePorIdQuery : IRequest<Hoteles.Dominio.Entidades.Cliente>

    {

        public int Id { get; set; }

    }

}
