using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Aplicacion.Proceso.Notificacion.GetById;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Notificacion.GetById
{
    public class ObtenerNotificacionPorIdQueryHandler : IRequestHandler<ObtenerNotificacionPorIdQuery, Hoteles.Dominio.Entidades.Notificacion>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerNotificacionPorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Hoteles.Dominio.Entidades.Notificacion> Handle(ObtenerNotificacionPorIdQuery request, CancellationToken cancellationToken)
        {
            var notificacion = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Notificacion>().GetByID(request.Id);
            return Task.FromResult(notificacion);
        }
    }
}
