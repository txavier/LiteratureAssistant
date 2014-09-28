using System;
namespace Auto.WebApiController
{
    public interface IApiController<TEntity>
     where TEntity : class, Auto.Repo.IEntity
    {
        System.Collections.Generic.IEnumerable<TEntity> Get();
    }
}
