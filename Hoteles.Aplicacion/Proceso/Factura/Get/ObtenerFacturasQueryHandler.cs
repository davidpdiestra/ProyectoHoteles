using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura.Get
{
    public class ObtenerFacturasQueryHandler : IRequestHandler<ObtenerFacturasQuery, IEnumerable<Hoteles.Dominio.Entidades.Factura>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerFacturasQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.Factura>> Handle(ObtenerFacturasQuery request, CancellationToken cancellationToken)
        {
            var facturas = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Factura>().Get();
            return Task.FromResult(facturas);
        }
    }
}
