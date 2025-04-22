using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.Get
{
    public class ObtenerCheckOutsQueryHandler : IRequestHandler<ObtenerCheckOutsQuery, IEnumerable<Hoteles.Dominio.Entidades.CheckOut>>

    {

        private readonly IUnitOfWork _unitOfWork;

        public ObtenerCheckOutsQueryHandler(IUnitOfWork unitOfWork)

        {

            _unitOfWork = unitOfWork;

        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.CheckOut>> Handle(ObtenerCheckOutsQuery request, CancellationToken cancellationToken)

        {

            var checkOuts = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckOut>().Get();

            return Task.FromResult(checkOuts);

        }

    }

}
