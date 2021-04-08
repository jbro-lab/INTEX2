using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace INTEX2.DAL
{
    /// <summary>
    /// Creates a generic repo for all other repos to be based on.
    /// </summary>
    public class GenericRepo<T> : IGenericRepository<T> where T : class
    {
        internal ApplicationDbContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepo(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Generic method to add a <typeparamref name="T"/> to the DbSet.
        /// </summary>
        /// <param name="objectToInsert"><typeparamref name="T"/> to add.</param>
        public virtual void Insert(T objectToInsert)
        {
            _dbSet.Add(objectToInsert);
        }

        /// <summary>
        /// Generic method to add multiple <typeparamref name="T"/>s to the DB.
        /// </summary>
        /// <param name="objectsToAdd">IEnumerable of <typeparamref name="T"/> to add.</param>
        public virtual void BulkInsert(IEnumerable<T> objectsToAdd)
        {
            _dbSet.AddRange(objectsToAdd);
        }

        /// <summary>
        /// Generic method to retrieves all <typeparamref name="T"/> records.
        /// </summary>
        /// <returns>IEnumerable of type T.</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        /// <summary>
        /// Generic method for returning all <typeparamref name="T"/>s with any Include calls.
        /// </summary>
        /// <param name="includes">Array of objects associated with <typeparamref name="T"/> to include in the results.</param>
        /// <returns>IEnumerable of <typeparamref name="T"/>s with objects included.</returns>
        public virtual IEnumerable<T> GetAll(
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.Include(includes[0]);
            foreach (var includeObject in includes.Skip(1))
            {
                query = query.Include(includeObject);
            }
            return query.AsEnumerable();
        }

        /// <summary>
        /// Finds a specific <typeparamref name="T"/> by PK.
        /// </summary>
        /// <param name="id">PK of the <typeparamref name="T"/> to find.</param>
        /// <returns><typeparamref name="T"/> with PK of <paramref name="id"/>.</returns>
        public virtual T GetByID(long id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Generic method to update a <typeparamref name="T"/> in the DB.
        /// </summary>
        /// <param name="objectToUpdate"><typeparamref name="T"/> to update.</param>
        public virtual void Update(T objectToUpdate)
        {
            _dbSet.Attach(objectToUpdate);
            _context.Entry(objectToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// Generic method to delete a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="objectToDelete"><typeparamref name="T"/> to delete from the DB.</param>
        // TODO Add error handling if an invalid object is passed.
        public virtual void Delete(T objectToDelete)
        {
            if (_context.Entry(objectToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(objectToDelete);
            }
            _dbSet.Remove(objectToDelete);
        }

        /// <summary>
        /// Generic method to delete a <typeparamref name="T"/> given the PK.
        /// </summary>
        /// <param name="id">PK of the <typeparamref name="T"/> to delete.</param>
        // TODO Add error handling if a wrong id is passed.
        public virtual void Delete(long id)
        {
            T objectToDelete = _dbSet.Find(id);
            _dbSet.Remove(objectToDelete);
        }
    }
}
