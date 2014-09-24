using System;
namespace Auto.Repo
{
    public interface IRepository<TEntity>
     where TEntity : class, IEntity
    {
        void Delete(int id);
        void Delete(TEntity entity);
        System.Linq.IQueryable<TEntity> GetAll();
        TEntity GetSingle(int entityId);
        void SaveChanges();
        void Update(TEntity entity);
    }
}
