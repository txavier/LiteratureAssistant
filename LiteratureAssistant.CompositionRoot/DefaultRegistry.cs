// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace LiteratureAssistant.CompositionRoot
{
    using AutoClutch.Auto.Repo.Interfaces;
    using AutoClutch.Auto.Repo.Objects;
    using AutoClutch.Auto.Service.Interfaces;
    using AutoClutch.Auto.Service.Services;
    using LiteratureAssistant.Core.Models;
    using LiteratureAssistant.Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using StructureMap.Web;
    using System.Data.Entity;
    using WildCard.Core.Interfaces;
    using WildCard.Core.Models;
    using WildCard.Core.Services;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            For<DbContext>().HybridHttpOrThreadLocalScoped().Use<LiteratureAssistantDbContext>();

            For(typeof(IService<>)).Use(typeof(Service<>));

            For(typeof(IRepository<>)).Use(typeof(Repository<>));

            For<IItemService>().Use<ItemService>();

            For<IUserService>().Use<UserService>();

            For<IOrderService>().Use<OrderService>();

            For<ICountService>().Use<CountService>();

            //For<IUserStore<MyUser>>().Use<MyUserStore>();
            
            //For<UserStore<MyUser>>().Use<MyUserStore>();

            //For<UserManager<MyUser>>().Use<MyUserManager>();

            For(typeof(IUserStore<>)).Use(typeof(UserStore<>));

            Policies.SetAllProperties(prop => prop.OfType<IService<item>>());

            Policies.SetAllProperties(prop => prop.OfType<IService<itemAttribute>>());

            Policies.SetAllProperties(prop => prop.OfType<IService<templateAttribute>>());

            Policies.SetAllProperties(prop => prop.OfType<IItemService>());

            Policies.SetAllProperties(prop => prop.OfType<IUserService>());

            Policies.SetAllProperties(prop => prop.OfType<IOrderService>());

            Policies.SetAllProperties(prop => prop.OfType<IUserStore<ApplicationUser>>());
        }

        #endregion
    }
}