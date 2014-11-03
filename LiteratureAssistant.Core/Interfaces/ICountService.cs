using System;
namespace LiteratureAssistant.Core.Interfaces
{
    public interface ICountService : AutoClutch.Auto.Service.Interfaces.IService<LiteratureAssistant.Core.Models.count>
    {
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.count> ToEntities(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.CountViewModel> countViewModels);
        LiteratureAssistant.Core.Models.count ToEntity(LiteratureAssistant.Core.ViewModels.CountViewModel countViewModel);
        LiteratureAssistant.Core.ViewModels.CountViewModel ToViewModel(LiteratureAssistant.Core.Models.count count);
        System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.ViewModels.CountViewModel> ToViewModels(System.Collections.Generic.IEnumerable<LiteratureAssistant.Core.Models.count> counts);
    }
}
