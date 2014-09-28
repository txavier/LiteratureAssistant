using Auto.Repo;
using Auto.Service;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.WebApiController
{
    public class ApiController<TEntity> : Auto.WebApiController.IApiController<TEntity> where TEntity : class, IEntity
    {
        private readonly IService<TEntity> service;

        public ApiController(IService<TEntity> service)
        {
            this.service = service;
        }

        public ApiController() :
            this(ObjectFactory.GetInstance<IService<TEntity>>())
        { }

        // GET: api/itemsApi
        public IEnumerable<TEntity> Get()
        {
            var result = service.GetAll();

            return result;
        }
    }
}
