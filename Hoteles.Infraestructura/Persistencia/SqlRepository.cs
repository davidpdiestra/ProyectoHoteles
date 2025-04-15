using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hoteles.Aplicacion.Interfaces.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Hoteles.Infraestructura.Persistencia
{
    /// <summary>
    /// Clase SqlRepository
    /// </summary>
    public class SqlRepository<TEntity> : ISqlRepository<TEntity> where TEntity : class
    {
        internal DbSet<TEntity> _dbSet;
        internal AppDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        public SqlRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        /// <summary>
        /// Busqueda de una lista
        /// </summary>
        /// <param name="filter">Filtro para obtener los datos</param>
        /// <param name="orderBy">Ordenación de los datos</param>
        /// <param name="includeProperties">Datos que cumplan las propiedades especificadas</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(
                    Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    string includeProperties = "",
                    bool asNoTracking = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Busqueda por ID
        /// </summary>
        /// <param name="id">Identificador del usuario</param>
        /// <returns></returns>
        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Busqueda por ID
        /// </summary>
        /// <param name="id">Identificador del usuario</param>
        /// <returns></returns>
        public virtual TEntity GetByGUID(Guid id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Insertar un nuevo registro
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            try
            {
                _context.Add(entity);
            }
            catch (Exception exc)
            {
                string s = exc.Message;
            }
        }

        /// <summary>
        /// Inserta múltiples registros de una sola vez.
        /// </summary>
        /// <param name="entities">Lista de entidades a insertar</param>
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        /// <summary>
        /// Borrar un registro
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        /// <summary>
        /// Borrado de un registro
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Actualización de un registro
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void DeleteRange(IEnumerable<TEntity> entityToDelete)
        {
            _dbSet.RemoveRange(entityToDelete);
        }

        public async Task InsertAsync(TEntity entity)

        {

            await _context.Set<TEntity>().AddAsync(entity);

        }

    }
}
