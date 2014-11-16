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

        public IEnumerable<CountViewModel> Get(string aggregateType)
        {
            var countViewModels = new List<CountViewModel>();

            switch (aggregateType)
            {
                case "monthlyTotals":
                    {
                        //countViewModels = _countService.ToViewModels(_countService.GetByMonth()).ToList();

                        break;
                    }
                default:
                    {
                        countViewModels = _countService.ToViewModels(_countService.GetAll()).ToList();

                        break;
                    }
            }

            return countViewModels;
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
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE: api/usersApi/5
        public void Delete(int id)
        {
            _countService.Delete(id);
        }
    }
}
