using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.CheckOut.Delete
{
    public class EliminarCheckOutCommandHandler : IRequestHandler<EliminarCheckOutCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EliminarCheckOutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(EliminarCheckOutCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.CheckOut>();
            var checkOut = repo.GetByID(request.Id);

            if (checkOut == null)
                return false;

            repo.Delete(checkOut);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
