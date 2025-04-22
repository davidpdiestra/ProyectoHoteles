using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Notificacion.Update
{
    public class ActualizarNotificacionCommandHandler : IRequestHandler<ActualizarNotificacionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarNotificacionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarNotificacionCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Notificacion>();
            var entity = repo.GetByID(request.Id);

            if (entity == null) return false;

            entity.Titulo = request.Titulo;
            entity.Mensaje = request.Mensaje;
            entity.FechaEnvio = request.FechaEnvio;
            entity.Enviada = request.Enviada;
            entity.ClienteId = request.ClienteId;
            entity.ReservaId = request.ReservaId;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
