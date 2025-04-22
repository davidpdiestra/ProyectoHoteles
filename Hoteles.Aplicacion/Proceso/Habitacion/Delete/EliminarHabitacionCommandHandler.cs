using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion.Delete
{
    public class EliminarHabitacionCommandHandler : IRequestHandler<EliminarHabitacionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarHabitacionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarHabitacionCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Habitacion>();
            var habitacion = repo.GetByID(request.Id);

            if (habitacion == null)
                return false;

            repo.Delete(habitacion);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
