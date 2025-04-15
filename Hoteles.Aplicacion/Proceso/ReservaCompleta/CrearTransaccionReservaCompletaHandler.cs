using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Hoteles.Dominio.Entidades;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.ReservaCompleta
{
    public class CrearTransaccionReservaCompletaHandler : IRequestHandler<CrearTransaccionReservaCompletaCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearTransaccionReservaCompletaHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearTransaccionReservaCompletaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // 1. Crear Reserva
                var reserva = new Hoteles.Dominio.Entidades.Reserva
                {
                    ClienteId = request.Reserva.ClienteId,
                    HabitacionId = request.Reserva.HabitacionId,
                    FechaInicio = request.Reserva.FechaInicio,
                    FechaFin = request.Reserva.FechaFin,
                    Estado = request.Reserva.Estado
                };
                await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Reserva>().InsertAsync(reserva);
                await _unitOfWork.SaveChangesAsync();

                // 2. Crear CheckIn
                var checkIn = new Hoteles.Dominio.Entidades.CheckIn
                {
                    ReservaId = reserva.Id,
                    FechaHoraIngreso = request.CheckIn.FechaHoraIngreso,
                    RecepcionistaId = request.CheckIn.RecepcionistaId
                };
                await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckIn>().InsertAsync(checkIn);

                // 3. Crear Pago
                var pago = new Pago
                {
                    ReservaId = reserva.Id,
                    PasarelaPagoId = request.Pago.PasarelaPagoId,
                    Monto = request.Pago.Monto,
                    FechaPago = request.Pago.FechaPago,
                    EstadoTransaccion = request.Pago.EstadoTransaccion
                };
                await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Pago>().InsertAsync(pago);

                // 4. Crear Factura
                var factura = new Hoteles.Dominio.Entidades.Factura
                {
                    CheckOutId = request.Factura.CheckOutId,
                    FechaEmision = request.Factura.FechaEmision,
                    MontoTotal = request.Factura.MontoTotal,
                    Detalle = request.Factura.Detalle
                };
                await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Factura>().InsertAsync(factura);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
                return reserva.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}
