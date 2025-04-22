using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente.Create
{
    public class CrearClienteCommandHandler : IRequestHandler<CrearClienteCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Dominio.Entidades.Cliente
            {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Email = request.Email,
                Telefono = request.Telefono,
                FechaNacimiento = request.FechaNacimiento,
                Activo = request.Activo
            };

            await _unitOfWork.GetRepository<Dominio.Entidades.Cliente>().InsertAsync(cliente);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return cliente.Id;
        }

    }
}
