using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Aplicacion.Proceso.Recibos.GetById;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos.GetById
{
    public class ObtenerReciboPorIdQueryHandler : IRequestHandler<ObtenerReciboPorIdQuery, Hoteles.Dominio.Entidades.Recibo>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerReciboPorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Hoteles.Dominio.Entidades.Recibo> Handle(ObtenerReciboPorIdQuery request, CancellationToken cancellationToken)
        {
            var recibo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Recibo>().GetByID(request.Id);
            return Task.FromResult(recibo);
        }
    }
}
