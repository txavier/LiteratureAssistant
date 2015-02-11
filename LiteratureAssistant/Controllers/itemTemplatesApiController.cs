using LiteratureAssistant.DependencyResolution;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WildCard.Core.Models;
using AutoClutch.Auto.Service;
using AutoClutch.Auto.Service.Interfaces;

namespace LiteratureAssistant.Controllers
{
    [RoutePrefix("api/itemTemplatesApi")]
    public class itemTemplatesApiController : ApiController
    {
        private readonly IService<itemTemplate> _itemTemplateService;

        public itemTemplatesApiController()
        {
            IContainer container = IoC.Initialize();

            _itemTemplateService = container.GetInstance<IService<itemTemplate>>();
        }

        // GET: api/organizationApi
        public IHttpActionResult Get()
        {
            var result = _itemTemplateService.Get();

            return Ok(result);
        }

        public IHttpActionResult Get(int itemTemplateId, int organizationId)
        {
            var result = _itemTemplateService
                .Get(filter: i => (itemTemplateId != -1) ? i.itemTemplateId == itemTemplateId : true
                                && (organizationId != -1) ? i.organizationId == organizationId : true);

            return Ok(result);
        }

        [Route("count")]
        public IHttpActionResult GetCount(int itemTemplateId, int organizationId)
        {
            var count = _itemTemplateService
                .GetCount(filter: i => (itemTemplateId != -1) ? i.itemTemplateId == itemTemplateId : true
                                && (organizationId != -1) ? i.organizationId == organizationId : true);

            var result = new List<int>() { count };

            return Ok(result);
        }

        // POST: api/organizationApi
        public IHttpActionResult Post(itemTemplate itemTemplate)
        {
            itemTemplate = _itemTemplateService.AddOrUpdate(itemTemplate);

            return Ok(itemTemplate);
        }

        // PUT: api/organizationApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/organizationApi/5
        public IHttpActionResult Delete(int id)
        {
            _itemTemplateService.Delete(id);

            return Ok();
        }
    }
}
