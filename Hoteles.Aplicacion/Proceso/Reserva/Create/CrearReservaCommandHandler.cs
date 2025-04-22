using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hoteles.Aplicacion.Proceso.Reserva.Create
{
    public class CrearReservaCommandHandler : IRequestHandler<CrearReservaCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearReservaCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearReservaCommand request, CancellationToken cancellationToken)
        {
            var reserva = new Dominio.Entidades.Reserva
            {
                ClienteId = request.ClienteId,
                HabitacionId = request.HabitacionId,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                Estado = request.Estado
            };

            await _unitOfWork.GetRepository<Dominio.Entidades.Reserva>().InsertAsync(reserva);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return reserva.Id;
        }
    }
}
