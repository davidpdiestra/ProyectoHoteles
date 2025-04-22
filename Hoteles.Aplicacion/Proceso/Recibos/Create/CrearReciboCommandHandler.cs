using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Aplicacion.Proceso.Recibos.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hoteles.Aplicacion.Proceso.Recibos.Create
{
    public class CrearReciboCommandHandler : IRequestHandler<CrearReciboCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearReciboCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearReciboCommand request, CancellationToken cancellationToken)
        {
            var recibo = new Dominio.Entidades.Recibo
            {
                PagoId = request.PagoId,
                NumeroRecibo = request.NumeroRecibo,
                FechaEmision = request.FechaEmision
            };

            await _unitOfWork.GetRepository<Dominio.Entidades.Recibo>().InsertAsync(recibo);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return recibo.Id;
        }
    }
}
