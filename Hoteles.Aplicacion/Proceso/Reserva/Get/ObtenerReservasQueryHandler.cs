using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Aplicacion.Proceso.Reserva.Get;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Reserva.Get
{
    public class ObtenerReservasQueryHandler : IRequestHandler<ObtenerReservasQuery, IEnumerable<Hoteles.Dominio.Entidades.Reserva>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerReservasQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.Reserva>> Handle(ObtenerReservasQuery request, CancellationToken cancellationToken)
        {
            var reservas = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Reserva>().Get();
            return Task.FromResult(reservas);
        }
    }
}
