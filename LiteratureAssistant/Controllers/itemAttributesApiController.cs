﻿using Auto.Service;
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
    public class itemAttributesApiController : ApiController
    {
        private readonly IService<itemAttribute> ItemAttributeService;

        public itemAttributesApiController()
        {
            ItemAttributeService = ObjectFactory.GetInstance<IService<itemAttribute>>();
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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/itemAttributesApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/itemAttributesApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/itemAttributesApi/5
        public void Delete(int id)
        {
        }
    }
}