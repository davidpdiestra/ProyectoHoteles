using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hoteles.Aplicacion.Interfaces.Persistencia
{
    public interface ISqlRepository<TEntity> where TEntity : class
    {
        /// <returns></returns>
        public IEnumerable<TEntity> Get(
                    Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    string includeProperties = "",
                    bool asNoTracking = false);

        /// <summary>
        /// Busqueda por ID
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns></returns>
        public TEntity GetByID(object id);


        /// <summary>
        /// Busqueda por GUID
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns></returns>
        public TEntity GetByGUID(Guid id);


        /// <summary>
        /// Insertar un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity);

        /// <summary>
        /// Inserta un rango de valores
        /// </summary>
        /// <param name="entities"></param>
        public void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Borrar un registro
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id);

        /// <summary>
        /// Borrado de un registro
        /// </summary>
        /// <param name="entityToDelete"></param>
        public void Delete(TEntity entityToDelete);

        /// <summary>
        /// Borrado de un rango de registros
        /// </summary>
        /// <param name="entityToDelete"></param>
        public void DeleteRange(IEnumerable<TEntity> entityToDelete);

        /// <summary>
        /// Actualización de un registro
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public void Update(TEntity entityToUpdate);

        Task InsertAsync(TEntity entity);


    }
}
