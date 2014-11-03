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
    public class OrderService : Service<order>, IOrderService
    {
        private readonly IRepository<order> _orderRepository;
        
        private readonly IUserService _userService;

        private readonly IItemService _itemService;

        public OrderService(IRepository<order> orderRepository, IUserService userService, IItemService itemService)
            : base(orderRepository)
        {
            _orderRepository = orderRepository;

            _userService = userService;

            _itemService = itemService;
        }

        public OrderViewModel ToViewModel(order order)
        {
            var orders = new List<order>() { order };

            var result = ToViewModels(orders).SingleOrDefault();

            return result;
        }

        public IEnumerable<OrderViewModel> ToViewModels(IEnumerable<order> orders)
        {
            var result = orders.Select(i =>  new OrderViewModel
            {
                orderedForUserFullName = i.user.firstName + " " + i.user.lastName,

                orderedByUserFullName = i.user1 == null ? null : i.user1.firstName + " " + i.user1.lastName,

                itemLabel = i.item.itemAttributes.Select(j => j.value).Aggregate((current, next) => current + " - " + next),

                orderId = i.orderId,

                itemId = i.itemId,

                orderedForUserId = i.orderedForUserId,

                date = i.date.ToShortDateString(),

                pending = i.pending,

                received = i.received,

                orderSent = i.orderSent,

                orderedByUserId = i.orderedByUserId

                //item = i.item == null ? null : ItemService.ToViewModel(i.item),

                //user = i.user == null ? null : UserService.ToViewModel(i.user)
            });

            return result;
        }

        public order ToEntity(OrderViewModel orderViewModel)
        {
            var orderViewModels = new List<OrderViewModel>() { orderViewModel };

            var result = ToEntities(orderViewModels).SingleOrDefault();

            return result;
        }

        public IEnumerable<order> ToEntities(IEnumerable<OrderViewModel> orderViewModels)
        {
            DateTime date = new DateTime();

            var result = orderViewModels.Select(i => new order
            {
                orderId = i.orderId,

                date = DateTime.TryParse(i.date, out date) ? date : DateTime.Today.Date,

                pending = i.pending,

                received = i.received,

                orderSent = i.orderSent,

                itemId = i.itemId != null ? (i.itemId ?? 0) : (string.IsNullOrEmpty(i.itemLabel) ? 0 : (_itemService.GetAll().ToList().Where(j => _itemService.GetItemLabel(j) == i.itemLabel).SingleOrDefault().itemId)),

                orderedForUserId = i.orderedForUserId != null ? (i.orderedForUserId ?? 0) : (_userService.Get(filter: j => (j.firstName + " " + j.lastName) == i.orderedForUserFullName).SingleOrDefault().userId),

                orderedByUserId = i.orderedByUserId != null ? (i.orderedByUserId ?? 0) : (i.orderedByUserFullName == null ? null : (int?)_userService.Get(filter: j => (j.firstName + " " + j.lastName) == i.orderedByUserFullName).SingleOrDefault().userId),

            }).ToList();

            return result;
        }
    }
}
