using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hoteles.Aplicacion.Proceso.Notificacion.Create
{
    public class CrearNotificacionCommandHandler : IRequestHandler<CrearNotificacionCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearNotificacionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearNotificacionCommand request, CancellationToken cancellationToken)
        {
            var notificacion = new Dominio.Entidades.Notificacion
            {
                Titulo = request.Titulo,
                Mensaje = request.Mensaje,
                FechaEnvio = request.FechaEnvio,
                Enviada = request.Enviada,
                ClienteId = request.ClienteId,
                ReservaId = request.ReservaId
            };

            await _unitOfWork.GetRepository<Dominio.Entidades.Notificacion>().InsertAsync(notificacion);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return notificacion.Id;
        }
    }
}
