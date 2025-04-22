using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva.Delete
{
    public class EliminarReservaCommandHandler : IRequestHandler<EliminarReservaCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarReservaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarReservaCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Reserva>();
            var reserva = repo.GetByID(request.Id);

            if (reserva == null)
                return false;

            repo.Delete(reserva);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
