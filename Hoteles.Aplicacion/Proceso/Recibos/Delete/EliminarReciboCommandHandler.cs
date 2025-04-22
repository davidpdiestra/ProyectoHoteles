using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Aplicacion.Proceso.Recibos.Delete;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos.Delete
{
    public class EliminarReciboCommandHandler : IRequestHandler<EliminarReciboCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarReciboCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarReciboCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Recibo>();
            var recibo = repo.GetByID(request.Id);

            if (recibo == null)
                return false;

            repo.Delete(recibo);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
