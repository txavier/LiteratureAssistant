using Auto.Service;
using Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LiteratureAssistant.Controllers
{
    public class templateAttributesApiController : ApiController
    {
        private readonly IService<templateAttribute> TemplateAttributeService;

        public templateAttributesApiController(IContainer container)
        {
            TemplateAttributeService = container.GetInstance<IService<templateAttribute>>();
        }

        // GET: api/templateAttribute
        public HttpResponseMessage Get()
        {
            var lightTemplateAttributeList = TemplateAttributeService.GetAll().Select(i => new
                {
                    templateAttributeName = i.templateAttributeName,
                    templateAttributeId = i.templateAttributeId
                });

            return this.Request.CreateResponse(lightTemplateAttributeList);
        }

        // GET: api/templateAttribute/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/templateAttribute
        public void Post([FromBody]string value)
        {
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
