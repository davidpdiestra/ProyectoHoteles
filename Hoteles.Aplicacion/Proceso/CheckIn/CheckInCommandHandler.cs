using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn
{
    public class CheckInCommandHandler : IRequestHandler<CheckInCommand, int>

    {

        private readonly IUnitOfWork _unitOfWork;

        public CheckInCommandHandler(IUnitOfWork unitOfWork)

        {

            _unitOfWork = unitOfWork;

        }

        public async Task<int> Handle(CheckInCommand request, CancellationToken cancellationToken)

        {

            var checkIn = new Hoteles.Dominio.Entidades.CheckIn

            {

                ReservaId = request.ReservaId,

                FechaHoraIngreso = request.FechaHoraIngreso,

                RecepcionistaId = request.RecepcionistaId

            };

            await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckIn>().InsertAsync(checkIn);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();

            return checkIn.Id;

        }

    }

}
