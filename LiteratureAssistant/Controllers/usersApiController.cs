using AutoClutch.Auto.Service.Interfaces;
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
        public UserViewModel Get(int id)
        {
            var user = UserService.ToViewModel(_userService.Find(id));

            return user;
        }

        // POST: api/usersApi
        public UserViewModel Post(JObject data)
        {
            try
            {
                dynamic dataDynamic = data;

                var userViewModel = new UserViewModel()
                {
                    firstName = dataDynamic.user.firstName,
                    lastName = dataDynamic.user.lastName,
                    userId = dataDynamic.user.userId ?? 0,
                    orders = dataDynamic.user.orders == null ? null : dataDynamic.user.orders.ToObject<List<OrderViewModel>>()
                };

                var result = _userService.AddOrUpdate(UserService.ToEntity(userViewModel));

                return UserService.ToViewModel(result);
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        // PUT: api/usersApi/5
        public void Put(int id, JObject data)
        {
        }

        // DELETE: api/usersApi/5
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
