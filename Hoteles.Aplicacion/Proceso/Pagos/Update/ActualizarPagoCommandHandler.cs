using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos.Update
{
    public class ActualizarPagoCommandHandler : IRequestHandler<ActualizarPagoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarPagoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarPagoCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Pago>();
            var entity = repo.GetByID(request.Id);

            if (entity == null) return false;

            entity.ReservaId = request.ReservaId;
            entity.PasarelaPagoId = request.PasarelaPagoId;
            entity.Monto = request.Monto;
            entity.FechaPago = request.FechaPago;
            entity.EstadoTransaccion = request.EstadoTransaccion;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
