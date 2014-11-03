using AutoClutch.Auto.Service.Interfaces;
using LiteratureAssistant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiteratureAssistant.Core.Interfaces
{
    public interface IOrderService : IService<order>
    {
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.order> ToEntities(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.OrderViewModel> orderViewModels);
        LiteratureAssistant.Core.Models.order ToEntity(LiteratureAssistant.Core.ViewModels.OrderViewModel orderViewModel);
        LiteratureAssistant.Core.ViewModels.OrderViewModel ToViewModel(LiteratureAssistant.Core.Models.order order);
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.OrderViewModel> ToViewModels(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.order> orders);
    }
}
