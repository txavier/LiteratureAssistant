using LiteratureAssistant.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WildCard.Core.Interfaces;

namespace LiteratureAssistant.Controllers
{
    public class testApiController : ApiController
    {
        private readonly IOrderService _orderService;

        public testApiController()
        {
            var container = IoC.Initialize();

            _orderService = container.GetInstance<IOrderService>();
        }

        public IHttpActionResult Get()
        {
            return Ok("hello");
        }
    }
}
