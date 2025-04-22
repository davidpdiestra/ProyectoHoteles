using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Pagos.GetById
{
    public class ObtenerPagoPorIdQueryHandler : IRequestHandler<ObtenerPagoPorIdQuery, Hoteles.Dominio.Entidades.Pago>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerPagoPorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Dominio.Entidades.Pago> Handle(ObtenerPagoPorIdQuery request, CancellationToken cancellationToken)
        {
            var pago = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Pago>().GetByID(request.Id);
            return Task.FromResult(pago);
        }
    }
}
