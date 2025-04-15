using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Habitacion
{
    public class CrearHabitacionCommandHandler : IRequestHandler<CrearHabitacionCommand, int>

    {

        private readonly IUnitOfWork _unitOfWork;

        public CrearHabitacionCommandHandler(IUnitOfWork unitOfWork)

        {

            _unitOfWork = unitOfWork;

        }

        public async Task<int> Handle(CrearHabitacionCommand request, CancellationToken cancellationToken)

        {

            var habitacion = new Hoteles.Dominio.Entidades.Habitacion

            {

                Numero = request.Numero,

                TipoHabitacionId = request.TipoHabitacionId,

                Precio = request.Precio,

                Disponible = request.Disponible,

                Descripcion = request.Descripcion

            };

            await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Habitacion>().InsertAsync(habitacion);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();

            return habitacion.Id;

        }

    }


}
