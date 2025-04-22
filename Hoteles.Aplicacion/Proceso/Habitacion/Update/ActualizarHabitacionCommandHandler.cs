using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.Update
{
    public class ActualizarHabitacionCommandHandler : IRequestHandler<ActualizarHabitacionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarHabitacionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarHabitacionCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Habitacion>();
            var entity = repo.GetByID(request.Id);

            if (entity == null) return false;

            entity.Numero = request.Numero;
            entity.TipoHabitacionId = request.TipoHabitacionId;
            entity.Precio = request.Precio;
            entity.Disponible = request.Disponible;
            entity.Descripcion = request.Descripcion;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
