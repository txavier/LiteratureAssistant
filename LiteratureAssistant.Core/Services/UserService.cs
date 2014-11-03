using AutoClutch.Auto.Repo.Interfaces;
using AutoClutch.Auto.Service.Services;
using LiteratureAssistant.Core.Interfaces;
using LiteratureAssistant.Core.Models;
using LiteratureAssistant.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureAssistant.Core.Services
{
    public class UserService : Service<user>, IUserService
    {
        private readonly IRepository<user> _userRepository;

        public UserService(IRepository<user> userRepository) :
            base(userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel ToViewModel(user user)
        {
            var users = new List<user>() { user };

            var result = ToViewModels(users).SingleOrDefault();

            return result;
        }

        public IEnumerable<UserViewModel> ToViewModels(IEnumerable<user> users)
        {
            var result = users.Select(i => new UserViewModel
                {
                    fullName = i.firstName + " " + i.lastName,
                    firstName = i.firstName,
                    lastName = i.lastName,
                    userId = i.userId,
                    //orders = i.orders == null ? null : OrderService.ToViewModels(i.orders)
                });

            return result;
        }

        public user ToEntity(UserViewModel userViewModel)
        {
            var result = ToEntities(new List<UserViewModel>() { userViewModel }).FirstOrDefault();

            return result;
        }

        public IEnumerable<user> ToEntities(IEnumerable<UserViewModel> userViewModels)
        {
            var result = userViewModels.Select(i => new user
            {
                firstName = i.firstName,
                lastName = i.lastName,
                userId = i.userId,
                //orders = i.orders == null ? null : _orderService.ToEntities(i.orders).ToList()
            });

            return result;
        }
    }
}
