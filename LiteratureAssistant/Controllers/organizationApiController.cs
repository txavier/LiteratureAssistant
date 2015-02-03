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
    public class organizationApiController : ApiController
    {
        private readonly IService<organization> _organizationService;

        public organizationApiController()
        {
            IContainer container = IoC.Initialize();

            _organizationService = container.GetInstance<IService<organization>>();
        }

        // GET: api/organizationApi
        public IHttpActionResult Get()
        {
            var result = _organizationService.Get();

            return Ok(result);
        }

        // GET: api/organizationApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/organizationApi
        public IHttpActionResult Post(organization organization)
        {
            organization = _organizationService.AddOrUpdate(organization);

            return Ok(organization);
        }

        // PUT: api/organizationApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/organizationApi/5
        public void Delete(int id)
        {
        }
    }
}
