using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Notificacion.Delete
{
    public class EliminarNotificacionCommandHandler : IRequestHandler<EliminarNotificacionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarNotificacionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarNotificacionCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Notificacion>();
            var notificacion = repo.GetByID(request.Id);

            if (notificacion == null)
                return false;

            repo.Delete(notificacion);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
