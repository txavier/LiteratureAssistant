using Auto.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Service
{
    public class Service<TEntity> : Auto.Service.IService<TEntity> where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;

        public Service(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public TEntity GetSingle(int entityId)
        {
            return repository.GetSingle(entityId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            var result = repository.GetAll().ToList();

            return result;
        }

        public void Update(TEntity entity)
        {
            repository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
