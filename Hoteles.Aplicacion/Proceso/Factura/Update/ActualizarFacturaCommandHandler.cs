using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura.Update
{
    public class ActualizarFacturaCommandHandler : IRequestHandler<ActualizarFacturaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarFacturaCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Factura>();
            var entity = repo.GetByID(request.Id);

            if (entity == null) return false;

            entity.CheckOutId = request.CheckOutId;
            entity.FechaEmision = request.FechaEmision;
            entity.MontoTotal = request.MontoTotal;
            entity.Detalle = request.Detalle;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
