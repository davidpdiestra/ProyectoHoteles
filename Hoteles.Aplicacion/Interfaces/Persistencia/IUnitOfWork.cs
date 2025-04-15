using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Aplicacion.Interfaces.Persistencia
{
    /// <summary>
    /// Interfaz que representa una unidad de trabajo
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Obtiene un repositorio
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        ISqlRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        /// <summary>
        /// Comienza una transacción
        /// </summary>
        /// <returns></returns>
        //Task<IDbContextTransaction> BeginTransactionAsync();

        /// <summary>
        /// Deshace los cambios de una transacción no commiteada
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync();

        /// <summary>
        /// Commitea un cambio
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();

        /// <summary>
        /// SaveChangesAsync
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
