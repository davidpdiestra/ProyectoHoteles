using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hoteles.Aplicacion.Proceso.Pagos.Create
{
    public class CrearPagoCommandHandler : IRequestHandler<CrearPagoCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearPagoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearPagoCommand request, CancellationToken cancellationToken)
        {
            var pago = new Dominio.Entidades.Pago
            {
                ReservaId = request.ReservaId,
                PasarelaPagoId = request.PasarelaPagoId,
                Monto = request.Monto,
                FechaPago = request.FechaPago,
                EstadoTransaccion = request.EstadoTransaccion
            };

            await _unitOfWork.GetRepository<Dominio.Entidades.Pago>().InsertAsync(pago);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return pago.Id;
        }
    }
}
