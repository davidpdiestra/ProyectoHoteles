using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Factura
{
    public class CrearFacturaCommandHandler : IRequestHandler<CrearFacturaCommand, int>

    {

        private readonly IUnitOfWork _unitOfWork;

        public CrearFacturaCommandHandler(IUnitOfWork unitOfWork)

        {

            _unitOfWork = unitOfWork;

        }

        public async Task<int> Handle(CrearFacturaCommand request, CancellationToken cancellationToken)

        {

            var factura = new Hoteles.Dominio.Entidades.Factura

            {

                CheckOutId = request.CheckOutId,

                FechaEmision = request.FechaEmision,

                MontoTotal = request.MontoTotal,

                Detalle = request.Detalle

            };

            await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Factura>().InsertAsync(factura);

            await _unitOfWork.SaveChangesAsync();

            await _unitOfWork.CommitAsync();

            return factura.Id;

        }

    }

}
