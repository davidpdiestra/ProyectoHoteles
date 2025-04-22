using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.GetById
{
    public class ObtenerCheckInPorIdQueryHandler : IRequestHandler<ObtenerCheckInPorIdQuery, Hoteles.Dominio.Entidades.CheckIn>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerCheckInPorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Hoteles.Dominio.Entidades.CheckIn> Handle(ObtenerCheckInPorIdQuery request, CancellationToken cancellationToken)
        {
            var checkIn = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckIn>().GetByID(request.Id);
            return Task.FromResult(checkIn);
        }
    }
}
