using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Repo
{
    public class Repository<TEntity> : Auto.Repo.IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _context;
        
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            _context = context;

            _dbSet = context.Set<TEntity>();
        }

        public TEntity GetSingle(int entityId)
        {
            return _dbSet.Find(entityId);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
