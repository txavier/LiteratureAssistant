using AutoClutch.Auto.Service.Interfaces;
using WildCard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteratureAssistant.Core.ViewModels;

namespace WildCard.Core.Interfaces
{
    public interface IOrderService : IService<order>
    {
        System.Collections.Generic.IEnumerable<WildCard.Core.Models.order> ToEntities(System.Collections.Generic.IEnumerable<WildCard.Core.ViewModels.OrderViewModel> orderViewModels);
        WildCard.Core.Models.order ToEntity(WildCard.Core.ViewModels.OrderViewModel orderViewModel);
        WildCard.Core.ViewModels.OrderViewModel ToViewModel(WildCard.Core.Models.order order);
        System.Collections.Generic.IEnumerable<WildCard.Core.ViewModels.OrderViewModel> ToViewModels(System.Collections.Generic.IEnumerable<WildCard.Core.Models.order> orders);
        IEnumerable<OrderByItemViewModel> GetOpenOrders();
    }
}
