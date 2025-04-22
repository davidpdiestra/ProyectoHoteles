using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.Delete
{
    public class EliminarCheckOutCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
