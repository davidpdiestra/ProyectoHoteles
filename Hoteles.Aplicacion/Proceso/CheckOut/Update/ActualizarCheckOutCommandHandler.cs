using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.Update
{
    public class ActualizarCheckOutCommandHandler : IRequestHandler<ActualizarCheckOutCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarCheckOutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarCheckOutCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckOut>();
            var checkOut = repo.GetByID(request.Id);

            if (checkOut == null)
                return false;

            checkOut.FechaHoraSalida = request.FechaHoraSalida;
            checkOut.TotalConsumos = request.TotalConsumos;
            checkOut.RecepcionistaId = request.RecepcionistaId;

            repo.Update(checkOut);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;

        }

    }


}
