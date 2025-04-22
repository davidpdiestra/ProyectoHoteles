using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente.Get
{
    public class ObtenerClientesQueryHandler : IRequestHandler<ObtenerClientesQuery, IEnumerable<Hoteles.Dominio.Entidades.Cliente>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerClientesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.Cliente>> Handle(ObtenerClientesQuery request, CancellationToken cancellationToken)
        {
            var clientes = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Cliente>().Get();
            return Task.FromResult(clientes);
        }
    }
}
