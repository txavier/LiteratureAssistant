﻿using AutoClutch.Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Omu.ValueInjecter;
using WildCard.Core.Interfaces;
using WildCard.Core.ViewModels;
using LiteratureAssistant.DependencyResolution;
using WildCard.Core.Models;

namespace LiteratureAssistant.Controllers
{
    public class usersApiController : ApiController
    {
        private readonly IUserService _userService;

        public usersApiController()
        {
            IContainer container = IoC.Initialize();

            _userService = container.GetInstance<IUserService>();
        }

        // GET: api/usersApi
        public IEnumerable<UserViewModel> Get()
        {
            var users = _userService.ToViewModels(_userService.GetAll());

            return users;
        }

        // GET: api/usersApi/5
        public UserViewModel Get(int id)
        {
            var user = _userService.ToViewModel(_userService.Find(id));

            return user;
        }

        // POST: api/usersApi
        public IHttpActionResult Post(user user)
        {
            try
            {
                user = _userService.AddOrUpdate(user);

                return Ok(_userService.ToViewModel(user));
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
            _userService.Delete(id);
        }
    }
}
