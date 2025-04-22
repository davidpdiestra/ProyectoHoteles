using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.Delete
{
    public class EliminarCheckInCommandHandler : IRequestHandler<EliminarCheckInCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarCheckInCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarCheckInCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckIn>();
            var checkIn = repo.GetByID(request.Id);

            if (checkIn == null)
                return false;

            repo.Delete(checkIn);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
