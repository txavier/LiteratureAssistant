using Auto.Repo;
using Auto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.WebApiController
{
    public class WebApiController<TEntity> : System.Web.Http.ApiController where TEntity : class, IEntity
    {
        private readonly IService<TEntity> service;

        public WebApiController(IService<TEntity> service)
        {
            this.service = service;
        }

        // GET: api/itemsApi
        public IQueryable<TEntity> Get()
        {
            return service.GetAll().AsQueryable();
        }
    }
}
