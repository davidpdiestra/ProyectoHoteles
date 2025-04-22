using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente.GetById
{
    public class ObtenerClientePorIdQueryHandler : IRequestHandler<ObtenerClientePorIdQuery, Hoteles.Dominio.Entidades.Cliente>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerClientePorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Hoteles.Dominio.Entidades.Cliente> Handle(ObtenerClientePorIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Cliente>().GetByID(request.Id);
            return Task.FromResult(cliente);
        }
    }
}
