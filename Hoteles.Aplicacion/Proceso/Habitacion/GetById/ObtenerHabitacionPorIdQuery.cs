using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.GetById
{
    public class ObtenerHabitacionPorIdQuery : IRequest<Hoteles.Dominio.Entidades.Habitacion>

    {

        public int Id { get; set; }

    }

}
