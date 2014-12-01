using AutoClutch.Auto.Service.Interfaces;
using WildCard.Core.Models;

namespace WildCard.Core.Interfaces
{
    public interface ITemplateAttributeService : IService<templateAttribute>
    {
        System.Collections.Generic.IEnumerable<WildCard.Core.Models.templateAttribute> ToEntities(System.Collections.Generic.IEnumerable<WildCard.Core.Models.TemplateAttributeViewModel> templateAttributeViewModels);

        WildCard.Core.Models.templateAttribute ToEntity(WildCard.Core.Models.TemplateAttributeViewModel templateAttributeViewModel);

        WildCard.Core.Models.TemplateAttributeViewModel ToViewModel(WildCard.Core.Models.templateAttribute templateAttribute);

        System.Collections.Generic.IEnumerable<WildCard.Core.Models.TemplateAttributeViewModel> ToViewModels(System.Collections.Generic.IEnumerable<WildCard.Core.Models.templateAttribute> templateAttributes);
    }
}