using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos.Update
{
    public class ActualizarReciboCommandHandler : IRequestHandler<ActualizarReciboCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarReciboCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarReciboCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Recibo>();
            var entity = repo.GetByID(request.Id);

            if (entity == null) return false;

            entity.PagoId = request.PagoId;
            entity.NumeroRecibo = request.NumeroRecibo;
            entity.FechaEmision = request.FechaEmision;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
