using AutoClutch.Auto.Service.Interfaces;
using LiteratureAssistant.Core.Interfaces;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.Core.Services;
using LiteratureAssistant.Core.ViewModels;
//using Newtonsoft.Json.Linq;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using Omu.ValueInjecter;

namespace LiteratureAssistant.Controllers
{
    public class countsApiController : ApiController
    {
        private readonly ICountService _countService;

        public countsApiController(IContainer container)
        {
            _countService = container.GetInstance<ICountService>();
        }

        // GET: api/usersApi
        public IEnumerable<CountViewModel> Get()
        {
            var counts = _countService.ToViewModels(_countService.GetAll());

            return counts;
        }

        // GET: api/usersApi/5
        public CountViewModel Get(int id)
        {
            var count = _countService.ToViewModel(_countService.Find(id));

            return count;
        }

        // POST: api/usersApi
        public void Post(CountViewModel countViewModel)
        {
            try
            {
                var result = _countService.AddOrUpdate(_countService.ToEntity(countViewModel));

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
            _countService.Delete(id);
        }
    }
}
