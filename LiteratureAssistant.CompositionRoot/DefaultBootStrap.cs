using Auto.Repo;
using Auto.Service;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.Data;
using StructureMap;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap.Web;
using Auto.WebApiController;

namespace LiteratureAssistant.CompositionRoot
{
    public class DefaultBootStrap : IBootstrapper
    {
        public void BootstrapStructureMap()
        {
            ObjectFactory.Configure(_ =>
            {
                _.For<DbContext>().HybridHttpOrThreadLocalScoped().Use<LiteratureAssistantDbModel>();

                _.For<IRepository<item>>().Use<Repository<item>>();
                _.For<IService<item>>().Use<Service<item>>();
                _.For<IApiController<item>>().Use<ApiController<item>>();

                _.Policies.SetAllProperties(prop => prop.OfType<IService<item>>());

            });

            //var container = new Container(_ =>
            //{

            //    _.For<IRepository<item>>().Use<Repository<item>>();
            //    _.For<IService<item>>().Use<Service<item>>();

            //    _.Policies.SetAllProperties(prop => prop.OfType<IService<item>>());

            //});
        }

        public static void Bootstrap()
        {
            new DefaultBootStrap().BootstrapStructureMap();
        }

       
    }
}
