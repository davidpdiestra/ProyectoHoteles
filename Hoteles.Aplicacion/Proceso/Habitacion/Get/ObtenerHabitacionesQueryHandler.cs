using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.Get
{
    public class ObtenerHabitacionesQueryHandler : IRequestHandler<ObtenerHabitacionesQuery, IEnumerable<Hoteles.Dominio.Entidades.Habitacion>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerHabitacionesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Hoteles.Dominio.Entidades.Habitacion>> Handle(ObtenerHabitacionesQuery request, CancellationToken cancellationToken)
        {
            var habitaciones = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Habitacion>().Get();
            return Task.FromResult(habitaciones);
        }
    }
}
