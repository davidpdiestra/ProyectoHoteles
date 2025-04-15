﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente
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
            var cliente = new Hoteles.Dominio.Entidades.Cliente
            {
                Nombre = request.Nombre,
                Email = request.Email
            };

            await _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Cliente>().InsertAsync(cliente);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return cliente.Id;
        }
    }
}
