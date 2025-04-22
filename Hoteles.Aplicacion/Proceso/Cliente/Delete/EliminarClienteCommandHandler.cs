using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente.Delete
{
    public class EliminarClienteCommandHandler : IRequestHandler<EliminarClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarClienteCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Cliente>();
            var cliente = repo.GetByID(request.Id);

            if (cliente == null)
                return false;

            repo.Delete(cliente);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
