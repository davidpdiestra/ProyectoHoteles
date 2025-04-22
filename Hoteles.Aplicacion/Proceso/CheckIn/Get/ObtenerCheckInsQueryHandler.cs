using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckIn.Get
{
    public class ObtenerCheckInsQueryHandler : IRequestHandler<ObtenerCheckInsQuery, IEnumerable<Hoteles.Dominio.Entidades.CheckIn>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerCheckInsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.CheckIn>> Handle(ObtenerCheckInsQuery request, CancellationToken cancellationToken)
        {
            var checkIns = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckIn>().Get();
            return Task.FromResult(checkIns);
        }
    }
}
