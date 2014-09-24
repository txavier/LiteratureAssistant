using Auto.Repo;
using Auto.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Auto.Controller
{
    public class Controller<TEntity> : System.Web.Mvc.Controller where TEntity : class, IEntity
    {
        private readonly IService<TEntity> service;

        public Controller(IService<TEntity> service)
        {
            this.service = service;
        }

        // GET: items
        public ActionResult Index()
        {
            var items = service.GetAll();

            return View(items);
        }
    }
}
