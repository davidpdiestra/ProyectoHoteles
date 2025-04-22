using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.GetById
{
    public class ObtenerCheckOutPorIdQueryHandler : IRequestHandler<ObtenerCheckOutPorIdQuery, Hoteles.Dominio.Entidades.CheckOut>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerCheckOutPorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Hoteles.Dominio.Entidades.CheckOut> Handle(ObtenerCheckOutPorIdQuery request, CancellationToken cancellationToken)
        {
            var checkOut = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckOut>().GetByID(request.Id);
            return Task.FromResult(checkOut);
        }
    }
}
