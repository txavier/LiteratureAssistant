using AutoClutch.Auto.Service;
using AutoClutch.Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.DependencyResolution;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WildCard.Core.Models;

namespace LiteratureAssistant.Controllers
{
    [RoutePrefix("api/itemAttributesApi")]
    public class itemAttributesApiController : ApiController
    {
        private readonly IService<itemAttribute> ItemAttributeService;

        public itemAttributesApiController()
        {
            IContainer container = IoC.Initialize();

            ItemAttributeService = container.GetInstance<IService<itemAttribute>>();
        }

        // GET: api/itemAttributesApi
        public HttpResponseMessage GetitemAttributes()
        {
            var lightResultList = ItemAttributeService.GetAll().Select(i => new
            {
                value = i.value
            });

            return this.Request.CreateResponse(
                HttpStatusCode.OK,
                lightResultList);
        }

        // GET: api/itemAttributesApi/5
        public IHttpActionResult Get(int id)
        {
            var result = ItemAttributeService.Find(id);

            return Ok(result);
        }

        [Route("count")]
        public IHttpActionResult GetCount()
        {
            var result = ItemAttributeService.GetCount();

            return Ok(result);
        }

        // POST: api/itemAttributesApi
        public IHttpActionResult Post(itemAttribute itemAttribute)
        {
            itemAttribute = ItemAttributeService.AddOrUpdate(itemAttribute);

            return Ok(itemAttribute);
        }

        // PUT: api/itemAttributesApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/itemAttributesApi/5
        public IHttpActionResult Delete(int id)
        {
            ItemAttributeService.Delete(id);

            return Ok();
        }
    }
}
