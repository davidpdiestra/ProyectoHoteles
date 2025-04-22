using Hoteles.Aplicacion.Interfaces.Persistencia;
using MediatR;

namespace Hoteles.Aplicacion.Proceso.Cliente.Update
{
    public class ActualizarClienteCommandHandler : IRequestHandler<ActualizarClienteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarClienteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ActualizarClienteCommand request, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<Hoteles.Dominio.Entidades.Cliente>();
            var entity = repo.GetByID(request.Id);

            if (entity == null) return false;

            entity.Nombre = request.Nombre; 
            entity.Apellido = request.Apellido;
            entity.Email = request.Email;
            entity.Telefono = request.Telefono;

            repo.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitAsync();

            return true;
        }
    }
}
