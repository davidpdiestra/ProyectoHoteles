using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.Update
{
    public class ActualizarCheckInCommandHandler : IRequestHandler<ActualizarCheckInCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarCheckInCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarCheckInCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckIn>();
            var checkIn = repo.GetByID(request.Id);

            if (checkIn == null)
                return false;

            checkIn.FechaHoraIngreso = request.FechaHoraIngreso;
            checkIn.RecepcionistaId = request.RecepcionistaId;

            repo.Update(checkIn);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
