using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace Hoteles.Infraestructura.Persistencia
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Devuelve un repositorio genérico para cualquier entidad.
        /// </summary>
        public ISqlRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new SqlRepository<TEntity>(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Inicia una transacción explícita SIEMPRE creando una nueva.
        /// </summary>
        //public async Task<IDbContextTransaction> BeginTransactionAsync()
        //{
        //    if (_transaction != null)
        //    {
        //        throw new InvalidOperationException("Ya hay una transacción activa. No se puede iniciar otra.");
        //    }

        //    _transaction = await _dbContext.Database.BeginTransactionAsync();
        //    return _transaction;
        //}

        /// <summary>
        /// Confirma la transacción y guarda los cambios en la base de datos.
        /// </summary>
        public async Task CommitAsync()
        {
            if (_transaction == null)
            {
                // No hay transacción activa, solo guarda los cambios
                await _dbContext.SaveChangesAsync();
                return;
            }

            try
            {
                await _dbContext.SaveChangesAsync(); // Guardar cambios antes de hacer commit
                await _transaction.CommitAsync();   // Confirmar transacción
            }
            catch
            {
                await RollbackAsync(); // Revertir si hay error
                throw;
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        /// <summary>
        /// Revierte la transacción en caso de error.
        /// </summary>
        public async Task RollbackAsync()
        {
            if (_transaction == null)
                return;

            try
            {
                await _transaction.RollbackAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al hacer rollback de la transacción.", ex);
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        /// <summary>
        /// Libera la transacción de memoria.
        /// </summary>
        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
