using Auto.Service.Interfaces;
using LiteratureAssistant.Core.Interfaces;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.Core.Services;
using LiteratureAssistant.Core.ViewModels;
using Newtonsoft.Json.Linq;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Omu.ValueInjecter;

namespace LiteratureAssistant.Controllers
{
    public class usersApiController : ApiController
    {
        private readonly IUserService _userService;

        public usersApiController(IContainer container)
        {
            _userService = container.GetInstance<IUserService>();
        }

        // GET: api/usersApi
        public IEnumerable<UserViewModel> Get()
        {
            var users = UserService.ToViewModels(_userService.GetAll());

            return users;
        }

        // GET: api/usersApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/usersApi
        public void Post(JObject data)
        {
            dynamic dataDynamic = data;

            var userViewModel = new UserViewModel()
            {
                firstName = dataDynamic.firstName,
                lastName = dataDynamic.lastName
            };

            _userService.Add(UserService.ToEntity(userViewModel));
        }

        // PUT: api/usersApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/usersApi/5
        public void Delete(int id)
        {
        }
    }
}
