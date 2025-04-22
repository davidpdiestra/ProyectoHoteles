using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura.Delete
{
    public class EliminarFacturaCommandHandler : IRequestHandler<EliminarFacturaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarFacturaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarFacturaCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Factura>();
            var factura = repo.GetByID(request.Id);

            if (factura == null)
                return false;

            repo.Delete(factura);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
