using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Notificacion.Get
{
    public class ObtenerNotificacionesQueryHandler : IRequestHandler<ObtenerNotificacionesQuery, IEnumerable<Hoteles.Dominio.Entidades.Notificacion>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerNotificacionesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.Notificacion>> Handle(ObtenerNotificacionesQuery request, CancellationToken cancellationToken)
        {
            var notificaciones = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Notificacion>().Get();
            return Task.FromResult(notificaciones);
        }
    }
}
