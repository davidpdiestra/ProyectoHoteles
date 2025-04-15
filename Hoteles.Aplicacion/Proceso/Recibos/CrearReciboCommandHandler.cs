using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Dominio.Entidades;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Recibos
{
    public class CrearReciboCommandHandler : IRequestHandler<CrearReciboCommand, int>

    {

        private readonly IUnitOfWork _unitOfWork;

        public CrearReciboCommandHandler(IUnitOfWork unitOfWork)

        {

            _unitOfWork = unitOfWork;

        }

        public async Task<int> Handle(CrearReciboCommand request, CancellationToken cancellationToken)

        {

            var recibo = new Recibo

            {

                PagoId = request.PagoId,

                NumeroRecibo = request.NumeroRecibo,

                FechaEmision = request.FechaEmision

            };

            await _unitOfWork.GetRepository<Recibo>().InsertAsync(recibo);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();

            return recibo.Id;

        }

    }

}
