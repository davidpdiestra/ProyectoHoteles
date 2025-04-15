using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Dominio.Entidades;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos
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
            var pago = new Pago
            {
                ReservaId = request.ReservaId,
                PasarelaPagoId = request.PasarelaPagoId,
                Monto = request.Monto,
                FechaPago = request.FechaPago,
                EstadoTransaccion = request.EstadoTransaccion
            };

            await _unitOfWork.GetRepository<Pago>().InsertAsync(pago);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();
            return pago.Id;
        }
    }
}
