using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.GetById
{
    public class ObtenerCheckOutPorIdQuery : IRequest<Hoteles.Dominio.Entidades.CheckOut>
    {
        public int Id { get; set; }
    }
}
