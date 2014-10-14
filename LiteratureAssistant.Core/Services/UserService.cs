using Auto.Repo.Interfaces;
using Auto.Service.Services;
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
        private readonly IOrderService _orderService;
        
        private readonly IRepository<user> _userRepository;

        public UserService(IOrderService orderService, IRepository<user> userRepository) :
            base(userRepository)
        {
            _orderService = orderService;

            _userRepository = userRepository;
        }

        public static UserViewModel ToViewModel(user user)
        {
            var users = new List<user>() { user };

            var result = ToViewModels(users).SingleOrDefault();

            return result;
        }

        public static IEnumerable<UserViewModel> ToViewModels(IEnumerable<user> users)
        {
            var result = users.Select(i => new UserViewModel
                {
                    firstName = i.firstName,
                    lastName = i.lastName,
                    userId = i.userId,
                    orders = OrderService.ToViewModels(i.orders)
                });

            return result;
        }

        public static user ToEntity(UserViewModel userViewModel)
        {
            var result = ToEntities(new List<UserViewModel>() { userViewModel }).FirstOrDefault();

            return result;
        }

        public static IEnumerable<user> ToEntities(IEnumerable<UserViewModel> userViewModels)
        {
            var result = userViewModels.Select(i => new user
            {
                firstName = i.firstName,
                lastName = i.lastName,
                userId = i.userId,
                orders = i.orders == null ? null : OrderService.ToEntities(i.orders).ToList()
            });

            return result;
        }
    }
}
