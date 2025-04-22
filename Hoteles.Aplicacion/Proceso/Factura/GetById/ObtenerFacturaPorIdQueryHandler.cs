using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura.GetById
{
    public class ObtenerFacturaPorIdQueryHandler : IRequestHandler<ObtenerFacturaPorIdQuery, Hoteles.Dominio.Entidades.Factura>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerFacturaPorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Hoteles.Dominio.Entidades.Factura> Handle(ObtenerFacturaPorIdQuery request, CancellationToken cancellationToken)
        {
            var factura = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Factura>().GetByID(request.Id);
            return Task.FromResult(factura);
        }
    }
}
