using System;
namespace Auto.Service
{
    public interface IService<TEntity>
     where TEntity : class, Auto.Repo.IEntity
    {
        void Delete(int id);
        void Delete(TEntity entity);
        System.Collections.Generic.IEnumerable<TEntity> GetAll();
        TEntity GetSingle(int entityId);
        void Update(TEntity entity);
    }
}
