using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Notificacion.GetById
{
    public class ObtenerNotificacionPorIdQuery : IRequest<Hoteles.Dominio.Entidades.Notificacion>

    {

        public int Id { get; set; }

    }

}
