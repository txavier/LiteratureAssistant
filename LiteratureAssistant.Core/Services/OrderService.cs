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
    public class OrderService : IOrderService
    {
        public OrderService()
        {
        }

        public static OrderViewModel ToViewModel(order user)
        {
            var orders = new List<order>() { user };

            var result = ToViewModels(orders).SingleOrDefault();

            return result;
        }

        public static IEnumerable<OrderViewModel> ToViewModels(IEnumerable<order> orders)
        {
            var result = orders.Select(i => new OrderViewModel
            {
                orderId = i.orderId,

                itemId = i.itemId,

                userId = i.userId,

                date = i.date,

                pending = i.pending,

                received = i.received,

                orderSent = i.orderSent,

                item = ItemService.ToViewModel(i.item),

                user = UserService.ToViewModel(i.user)
            });

            return result;
        }

        internal static IEnumerable<order> ToEntities(IEnumerable<OrderViewModel> orderViewModels)
        {
            var result = orderViewModels.Select(i => new order
            {
                orderId = i.orderId,

                itemId = i.itemId,

                userId = i.userId,

                date = i.date,

                pending = i.pending,

                received = i.received,

                orderSent = i.orderSent,

                item = ItemService.ToEntity(i.item),

                user = UserService.ToEntity(i.user)
            });

            return result;
        }
    }
}
