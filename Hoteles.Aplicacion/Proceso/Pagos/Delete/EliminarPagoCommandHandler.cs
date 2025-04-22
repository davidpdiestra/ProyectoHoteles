using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Aplicacion.Proceso.Pagos.Delete;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos.Delete
{
    public class EliminarPagoCommandHandler : IRequestHandler<EliminarPagoCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarPagoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarPagoCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Pago>();
            var pago = repo.GetByID(request.Id);

            if (pago == null)
                return false;

            repo.Delete(pago);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
