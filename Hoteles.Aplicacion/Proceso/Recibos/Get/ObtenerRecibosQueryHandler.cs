using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos.Get
{
    public class ObtenerRecibosQueryHandler : IRequestHandler<ObtenerRecibosQuery, IEnumerable<Hoteles.Dominio.Entidades.Recibo>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerRecibosQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.Recibo>> Handle(ObtenerRecibosQuery request, CancellationToken cancellationToken)
        {
            var recibos = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Recibo>().Get();
            return Task.FromResult(recibos);
        }
    }
}
