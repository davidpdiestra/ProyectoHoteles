using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;
using Hoteles.Dominio.Entidades;

namespace Hoteles.Aplicacion.Proceso.Notificacion
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

            var notificacion = new Hoteles.Dominio.Entidades.Notificacion

            {

                Titulo = request.Titulo,

                Mensaje = request.Mensaje,

                FechaEnvio = request.FechaEnvio,

                ClienteId = request.ClienteId,

                ReservaId = request.ReservaId,

                Enviada = false

            };

            await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Notificacion>().InsertAsync(notificacion);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();

            return notificacion.Id;

        }

    }

}
