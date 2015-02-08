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
        public IEnumerable<OrderViewModel> Get()
        {
            var orders = _orderService.ToViewModels(_orderService.GetAll());

            return orders;
        }

        // GET: api/usersApi/5
        public OrderViewModel Get(int id)
        {
            var order = _orderService.ToViewModel(_orderService.Find(id));

            return order;
        }

        // POST: api/usersApi
        public void Post(OrderViewModel orderViewModel)
        {
            try
            {
                var result = _orderService.AddOrUpdate(_orderService.ToEntity(orderViewModel));

                //return OrderService.ToViewModel(result);
            }
            catch (Exception ex)
            {
                
                throw;
            }
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
