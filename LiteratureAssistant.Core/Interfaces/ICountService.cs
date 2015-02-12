using System;

namespace WildCard.Core.Interfaces
{
    public interface ICountService : AutoClutch.Auto.Service.Interfaces.IService<WildCard.Core.Models.count>
    {
        System.Collections.Generic.IEnumerable<WildCard.Core.Models.count> ToEntities(System.Collections.Generic.IEnumerable<WildCard.Core.ViewModels.CountViewModel> countViewModels);
        WildCard.Core.Models.count ToEntity(WildCard.Core.ViewModels.CountViewModel countViewModel);
        WildCard.Core.ViewModels.CountViewModel ToViewModel(WildCard.Core.Models.count count);
        System.Collections.Generic.IEnumerable<WildCard.Core.ViewModels.CountViewModel> ToViewModels(System.Collections.Generic.IEnumerable<WildCard.Core.Models.count> counts);
        //System.Collections.Generic.IEnumerable<Models.count> GetByMonth();
        object GetCurrentlyOnHandPerMonth();
        WildCard.Core.ViewModels.CountViewModel ToNewCountViewModel(int itemId);
        WildCard.Core.ViewModels.CountViewModel AddCount(ViewModels.CountViewModel countViewModel);
        WildCard.Core.ViewModels.CountViewModel SubtractCount(ViewModels.CountViewModel countViewModel);
    }
}
