using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva.Update
{
    public class ActualizarReservaCommandHandler : IRequestHandler<ActualizarReservaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarReservaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarReservaCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Reserva>();
            var entity = repo.GetByID(request.Id);

            if (entity == null) return false;

            entity.ClienteId = request.ClienteId;
            entity.HabitacionId = request.HabitacionId;
            entity.FechaInicio = request.FechaInicio;
            entity.FechaFin = request.FechaFin;
            entity.Estado = request.Estado;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
