using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hoteles.Aplicacion.Proceso.Factura.Create
{
    public class CrearFacturaCommandHandler : IRequestHandler<CrearFacturaCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearFacturaCommand request, CancellationToken cancellationToken)
        {
            var factura = new Dominio.Entidades.Factura
            {
                CheckOutId = request.CheckOutId,
                FechaEmision = request.FechaEmision,
                MontoTotal = request.MontoTotal,
                Detalle = request.Detalle
            };

            await _unitOfWork.GetRepository<Dominio.Entidades.Factura>().InsertAsync(factura);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return factura.Id;
        }
    }
}
