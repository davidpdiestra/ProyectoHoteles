using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva.GetById
{
    public class ObtenerReservaPorIdQueryHandler : IRequestHandler<ObtenerReservaPorIdQuery, Hoteles.Dominio.Entidades.Reserva>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerReservaPorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Hoteles.Dominio.Entidades.Reserva> Handle(ObtenerReservaPorIdQuery request, CancellationToken cancellationToken)
        {
            var reserva = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Reserva>().GetByID(request.Id);
            return Task.FromResult(reserva);
        }
    }
}
