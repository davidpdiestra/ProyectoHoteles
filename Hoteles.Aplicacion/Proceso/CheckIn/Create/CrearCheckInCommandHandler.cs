using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.Create
{
    public class CrearCheckInCommandHandler : IRequestHandler<CrearCheckInCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearCheckInCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearCheckInCommand request, CancellationToken cancellationToken)
        {
            var checkIn = new Dominio.Entidades.CheckIn
            {
                ReservaId = request.ReservaId,
                FechaHoraIngreso = request.FechaHoraIngreso,
                RecepcionistaId = request.RecepcionistaId
            };

            await _unitOfWork.GetRepository<Dominio.Entidades.CheckIn>().InsertAsync(checkIn);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return checkIn.Id;
        }
    }
}
