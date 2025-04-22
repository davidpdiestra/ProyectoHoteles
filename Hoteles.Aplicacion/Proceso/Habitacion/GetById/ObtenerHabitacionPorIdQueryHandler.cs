using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.GetById
{
    public class ObtenerHabitacionPorIdQueryHandler : IRequestHandler<ObtenerHabitacionPorIdQuery, Hoteles.Dominio.Entidades.Habitacion>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerHabitacionPorIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Hoteles.Dominio.Entidades.Habitacion> Handle(ObtenerHabitacionPorIdQuery request, CancellationToken cancellationToken)
        {
            var habitacion = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Habitacion>().GetByID(request.Id);
            return Task.FromResult(habitacion);
        }
    }
}
