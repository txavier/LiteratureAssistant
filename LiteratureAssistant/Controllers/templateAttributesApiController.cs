using AutoClutch.Auto.Service;
using AutoClutch.Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.DependencyResolution;
using Newtonsoft.Json.Linq;
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
    [RoutePrefix("api/templateAttributesApi")]
    public class templateAttributesApiController : ApiController
    {
        private readonly IService<templateAttribute> TemplateAttributeService;

        public templateAttributesApiController()
        {
            IContainer container = IoC.Initialize();
            
            TemplateAttributeService = container.GetInstance<IService<templateAttribute>>();
        }

        public IHttpActionResult Get()
        {
            var lightTemplateAttributeList = TemplateAttributeService.GetAll().Select(i => new
            {
                templateAttributeName = i.templateAttributeName,
                templateAttributeId = i.templateAttributeId
            }).ToList();

            return Ok(lightTemplateAttributeList.ToArray());
        }

        // GET: api/templateAttribute
        public IHttpActionResult Get(int templateAttributeId, int itemTemplateId)
        {
            var lightTemplateAttributeList = TemplateAttributeService
                .Get(filter: i => (templateAttributeId != -1) ? i.templateAttributeId == templateAttributeId: true
                                && (itemTemplateId != -1) ? i.itemTemplateId == itemTemplateId : true)
                .Select(i => new
                {
                    templateAttributeName = i.templateAttributeName,
                    templateAttributeId = i.templateAttributeId
                }).ToList();

            return Ok(lightTemplateAttributeList.ToArray());
        }

        [Route("count")]
        public IHttpActionResult GetCount(int templateAttributeId, int itemTemplateId)
        {
            var count = TemplateAttributeService
                .GetCount(filter: i => (templateAttributeId != -1) ? i.templateAttributeId == templateAttributeId : true
                                && (itemTemplateId != -1) ? i.itemTemplateId == itemTemplateId : true);

            var result = new List<int>();

            result.Add(count);

            return Ok(result);
        }

        // GET: api/templateAttribute/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/templateAttribute
        public IHttpActionResult Post(templateAttribute templateAttribute)
        {
            templateAttribute = TemplateAttributeService.Add(templateAttribute);

            return Ok(templateAttribute);
        }

        // PUT: api/templateAttribute/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/templateAttribute/5
        public void Delete(int id)
        {
        }
    }
}
