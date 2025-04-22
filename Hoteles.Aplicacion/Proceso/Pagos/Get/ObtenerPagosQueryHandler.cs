using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos.Get
{
    public class ObtenerPagosQueryHandler : IRequestHandler<ObtenerPagosQuery, IEnumerable<Hoteles.Dominio.Entidades.Pago>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerPagosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.Pago>> Handle(ObtenerPagosQuery request, CancellationToken cancellationToken)
        {
            var pagos = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Pago>().Get();
            return Task.FromResult(pagos);
        }
    }
}
