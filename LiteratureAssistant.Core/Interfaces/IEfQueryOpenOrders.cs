using System.Collections.Generic;
using LiteratureAssistant.Core.ViewModels;

namespace LiteratureAssistant.Core.Interfaces
{
    public interface IEfQueryOpenOrders
    {
        IEnumerable<OrderByItemViewModel> QueryOpenOrders();
    }
}