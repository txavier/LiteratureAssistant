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
using WildCard.Core.Interfaces;
using WildCard.Core.ViewModels;

namespace LiteratureAssistant.Controllers
{
    public class ordersApiController : ApiController
    {
        private readonly IOrderService _orderService;

        public ordersApiController()
        {
            IContainer container = IoC.Initialize();

            _orderService = container.GetInstance<IOrderService>();
        }

        // GET: api/usersApi
        public IHttpActionResult Get()
        {
            var orders = _orderService.ToViewModels(_orderService.GetAll()).OrderByDescending(i => i.date);

            return Ok(orders);
        }

        // GET: api/usersApi/5
        public IHttpActionResult Get(int id)
        {
            var order = _orderService.ToViewModel(_orderService.Find(id));

            return Ok(order);
        }

        // POST: api/usersApi
        public IHttpActionResult Post(OrderViewModel orderViewModel)
        {
            var result = _orderService.AddOrUpdate(_orderService.ToEntity(orderViewModel));

            return Ok();
        }

        // PUT: api/usersApi/5
        //public void Put(int id, JObject data)
        //{
        //}

        // DELETE: api/usersApi/5
        public void Delete(int id)
        {
            _orderService.Delete(id);
        }
    }
}