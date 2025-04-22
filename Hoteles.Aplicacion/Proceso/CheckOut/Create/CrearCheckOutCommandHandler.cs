using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.Create
{
    public class CrearCheckOutCommandHandler : IRequestHandler<CrearCheckOutCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearCheckOutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearCheckOutCommand request, CancellationToken cancellationToken)
        {
            var checkOut = new Dominio.Entidades.CheckOut
            {
                ReservaId = request.ReservaId,
                FechaHoraSalida = request.FechaHoraSalida,
                TotalConsumos = request.TotalConsumos,
                RecepcionistaId = request.RecepcionistaId
            };

            await _unitOfWork.GetRepository<Dominio.Entidades.CheckOut>().InsertAsync(checkOut);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return checkOut.Id;
        }
    }
}
